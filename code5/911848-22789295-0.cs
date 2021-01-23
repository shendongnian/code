    using System;
    
    namespace So2
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			
    			System.Net.WebRequest req = System.Net.WebRequest.Create("http://www.google.com");
    			
    			System.Net.WebResponse response = req.GetResponse();
    			
    			string source = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
    			
    			Console.WriteLine(source);
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    	}
    }
