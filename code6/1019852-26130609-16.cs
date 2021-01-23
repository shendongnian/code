    using System;
    
    namespace MyAutoFacTest
    {
    	public class EmailProcessor : IProcessor
    	{
    		public void Process(string formattedString)
    		{
    			Console.WriteLine("Email Processor sending out an email receipt");
    		}
    	}
    }
