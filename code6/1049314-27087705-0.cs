    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SimpleCSConsole
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			for (int i = 0; i < 1000; i++)
    			{
    	
    				decimal decimalValue = i / 1000m;
    	
    				double doubleValue = i / 1000.0;
    	
    	
    	
    				decimal numeratorDecimal = Math.Round(decimalValue * 1000m / 125m);
    	
    				int numeratorFloat = (int) Math.Round(doubleValue * 1000.0 / 125.0);
    	
    				int numeratorInt = (int)(doubleValue * 1000) / 125;
    	
    	
    	
    				if (numeratorFloat != numeratorInt ||
    	
    					numeratorFloat != numeratorDecimal ||
    	
    					numeratorInt != numeratorDecimal)
    	
    				{
    	
    					Console.WriteLine("{0,5}: Floating point: {1} Integer: {2} Decimal: {3}",
    	
    									i, numeratorFloat, numeratorInt, numeratorDecimal);
    	
    				}
    	
    			}
    	
    		}
    	
    	}
    }
