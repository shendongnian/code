    using System;
    
    namespace MyAutoFacTest
    {
    	public class PrinterProcessor : IProcessor
    	{
    		private IPrinter _printer;
    
    		public PrinterProcessor(IPrinter printer)
    		{
    			this._printer = printer;
    		}
    
    		public void Process(string formattedString)
    		{
    			Console.WriteLine("Printer processor sending receipt to printer.");
    			this._printer.Print();
    		}
    	}
    }
