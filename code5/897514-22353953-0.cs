    using System;
    
    namespace SO5
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			Console.WriteLine("Hello World!");
    			
    			Console.WriteLine(TestPostcode("1234 XC"));
    			Console.WriteLine(TestPostcode("D4 XC"));
    			Console.WriteLine(TestPostcode("4632 XC1"));
    		
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    		
    		public static bool TestPostcode(string input)
    		{
    			System.Text.StringBuilder sb = new System.Text.StringBuilder();
    			foreach (char c in input)
    			{
    				if (char.IsLetter(c))
    				{
    					sb.Append("L");
    				}
    				else if (char.IsNumber(c))
    				{
    					sb.Append("N");
    				}
    			}
    			
    			return sb.ToString() == "NNNNLL";
    			
    		}
    		
    	}
    }
