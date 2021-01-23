    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            tester.writeOut();
        }
    }
    class Something
    {
        private int firstDimensionLenght = 10;
        private int secondDimensionLenght = 10;
        private int[,] xArray;
        public Something()
        {
            xArray = new int[firstDimensionLenght, secondDimensionLenght];
            for (int row = 0; row < xArray.GetLength(0); row++)
                for (int col = 0; col < xArray.GetLength(1); col++)
                    xArray[row, col] = 1;
        }
        public int[,] XArray
        {
            get { return xArray; }
        }
    }
    class tester
    {
        static Something some;
        public static void writeOut()
        {
            some = new Something();
            for (int row = 0; row < some.XArray.GetLength(0); row++)
                for (int col = 0; col < some.XArray.GetLength(1); col++)
                    Console.Write(some.XArray[row, col].ToString());
        }
    }
    }
