﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    // INSP RS Consider naming this and other Report classes in a way that self documents relationship with Order superclass.
    class CuttingListReport : Order
    {
        // INSP RS This should be private and maybe const. Possibly defined by constructor instead of magic number.
        public int tableWidth = 20;
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }
        // INSP RS Code for report generation and printing is duplicated across subclasses. Consider moving to superclass or better yet a dedicated UI class. 
        // GenerateReport, generateTable, PrintLine, PrintRow, AlignCentre methods are all duplicated.
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }
        public void generateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square",base.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", base.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }


    }
}
