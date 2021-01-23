    using System;
    namespace TestConsole
    {
    	class Program
    	{
		    static void Main(string[] args)
		    {
    			Console.WriteLine("Testing");
			    if (System.Diagnostics.Debugger.IsAttached)
    			{
    				Console.WriteLine("Debugging; press a key to continue...");
    				Console.ReadKey();
    			}
    		}
    	}
    }
