    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test = "This is a test";
                char[] testArr = test.ToPaddedCharArray(32);
                for (int i = 0; i < testArr.Length; i++)
                {
                    Console.WriteLine("{0} = {1}", testArr[i], (int)testArr[i]);
                }
            }
        }
    
        public static class MyExtensions
        {
            public static char[] ToPaddedCharArray(this String str, int length)
            {
                char[] arr = new char[length];
                int minl = Math.Min(str.Length, length-1);
                for (int i = 0; i < minl; i++)
                {
                    arr[i] = str[i];
                }
                for (int i = minl; i < length; i++)
                {
                    arr[minl] = (char)0;
                }
                return arr;
            }
        }
    
    }
