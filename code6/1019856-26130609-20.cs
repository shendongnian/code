    using System;
    
    namespace MyAutoFacTest
    {
    	public class Receipt : IReceipt
    	{
    		private IFormatter _formatter;
    		private IProcessor _processor;
    
    		public Receipt(IFormatter formatter, IProcessor processor)
    		{
    			this._formatter = formatter;
    			this._processor = processor;
    		}
    
    		public Receipt(IFormatter formatter)
    		{
    			this._formatter = formatter;
    		}
    
    		public Receipt(IProcessor processor)
    		{
    			this._processor = processor;
    		}
    
    		public void PrintReceipt(int id)
    		{
    			var formattedString = this._formatter.GetFormattedString(id);
    			Console.WriteLine(formattedString);
    
    			this._processor.Process(formattedString);
    		}
    	}
    }
