    using System;
    using System.Collections.Generic;
    
    namespace MyFunctions
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			printABCSolution(1, -3, 4);
    			printABCSolution(1, -4, 4);
    			printABCSolution(1, -5, 4);
    			printABCSolution(9, 30, 25);
    			printABCSolution(9, -15, 25);
    
    			Console.ReadKey();
    		}
    
    		private static void printABCSolution(double a, double b, double c)
    		{
    			Console.WriteLine($"Solution a={a} b={b} c={c}");
    			var solution = ABCMath.ABCFormula(a, b, c);
    			Console.WriteLine($"# Solutions found: {solution.Count}");
    			solution.ForEach(x => Console.WriteLine($"x={x}"));
    		}
    
    	}
    
    	public static class ABCMath
    	{
    		public static List<double> ABCFormula(double a, double b, double c)
    		{
    			// Local formula
    			double formula(int plusOrMinus, double d) => (-b + (plusOrMinus * Math.Sqrt(d))) / (2 * a);
    			double discriminant = b * b - 4 * a * c;
    
    			List<double> result = new List<double>();
    			if (discriminant >= 0)
    			{
    				result.Add(formula(1, discriminant));
    				if (discriminant > 0)
    					result.Add(formula(-1, discriminant));
    			}
    			return result;
    		}
    	}
    }
