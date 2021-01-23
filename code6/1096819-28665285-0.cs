    using System;
    
    public class Cell
    {
        public Cell(int x) {}
    }
    
    public class Cells
    {
        public Cells(params Cell[] cells) { Console.WriteLine("Called with " + cells.Length.ToString() + " elements"); }
    }
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.Write("Test #1: ");
               Cells c1 = new Cells(new Cell[] { new Cell(1), new Cell(2)});
                Console.Write("Test #2: ");
               Cells c2 = new Cells(new Cell(4), new Cell(5));
            }
        }
    }
