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
        //Add some intellisence information stating you clone the initial array
        public int[,] XArrayCopy
        {
            get { return (int[,])xArray.Clone(); }
        }
    }
    class tester
    {
        static Something some;
        //We dont want to initialize "some" every time, do we? This constructor
        //is called implicitly the first time you call a method or property in tester
        static tester(){
            some = new Something()
        }
        //This code is painfuly long to execute compared to what it does
        public static void writeOut()
        {
            for (int row = 0; row < some.XArrayCopy.GetLength(0); row++)
                for (int col = 0; col < some.XArrayCopy.GetLength(1); col++)
                    Console.Write(some.XArrayCopy[row, col].ToString());
        }
        //This code should be much smoother
        public static void wayMoreEfficientWriteOut()
        {
            int[,] localArray = some.XArrayCopy();
            for (int row = 0; row < localArray.GetLength(0); row++)
                for (int col = 0; col < localArray.GetLength(1); col++)
                    Console.Write(localArray[row, col].ToString());
        }
    }
    }
