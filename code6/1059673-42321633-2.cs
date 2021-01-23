    using System;
    using System.Collections.Generic;
    
    namespace Rextester
    {
        public static class MyExtensions
        {
            public static string Extend(this Array array)
            {
                return "Yes, you can extend an array";
            }
            
            public static T[] column<T>(this T[,] multidimArray,int wanted_column)
            {
                int l=multidimArray.GetLength(0);
                T[] columnArray = new T[l];
                for(int i=0;i<l;i++)
                {
                  columnArray[i]=multidimArray[i,wanted_column];
                }
                return columnArray;
            }
    
            public static T[] row<T>(this T[,] multidimArray,int wanted_row)
            {
                int l=multidimArray.GetLength(1);
                T[] rowArray = new T[l];
                for(int i=0;i<l;i++)
                {
                  rowArray[i]=multidimArray[wanted_row,i];
                }
                return rowArray;
            }
            
            
        } 
    
        public class Program
        {
    
            
            public static void Main(string[] args)
            {
                    Console.WriteLine("Hello, world!");
    
                    int [,] multidimArray = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
                    Console.WriteLine(string.Join(" ",multidimArray.column(0)));
                    Console.WriteLine(string.Join(" ",multidimArray.row(0)));
                    
            }
        }
    }
