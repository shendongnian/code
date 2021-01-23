    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace CSharp
    {
    	public class Class1
    	{
    		public static void Main(string[] args)
    		{
    		   try
    		   {
    		      throw new ArgumentException("BANG!");
    		   }
    		   catch (ArgumentException)
    		   {
    		       Console.WriteLine("Catch 1");
    		       throw;
    		   }
    		   catch
    		   {
    		       Console.WriteLine("Catch 2");
    		   }
    		}
    	}
    }
