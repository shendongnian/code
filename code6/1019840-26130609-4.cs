    using System;
    
    namespace AutoFac
    {
    	public class PrinterProcessor : IProcessor
    	{
    		public void Process(string formattedString)
    		{
    			Console.WriteLine("Printer processor sending receipt to printer.");
    		}
    	}
    }
