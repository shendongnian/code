	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	
	namespace ConsoleApplication
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            int[] r1 = Split(140, 30);
	            Print(r1);
	
	            int[] r2 = Split(140, 40);
	            Print(r2);
	
	            int[] r3 = Split(75, 40);
	            Print(r3);
	        }
	
	        public static void Print(int[] arr)
	        {
	            for (int i = 0; i < arr.Length; i++)
	            {
	                Console.Write(arr[i] + " ");
	            }
	            Console.WriteLine();
	        }
	
	        public static int[] Split(int N, int val)
	        {
	            List<int> lst = new List<int>();
	            int M = N;
	            int v = 0;
	            while (M > 0)
	            {
	                v = M > val ? val : M;
	                lst.Add(v);
	                M -= v;
	            }
	            return lst.ToArray();
	        }
	    }
	}
	
	
	
	
	
	
	
