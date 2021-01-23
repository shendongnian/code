    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Sample_04_04_2014_01
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			try
    			{
    			Parallel.For(0,20, i => {
    			             	Console.WriteLine(i);
    			             	if(i == 5)
    			             		throw new InvalidOperationException();
    			             	Thread.Sleep(100);
    			             });
    			}
    			catch(AggregateException){}
    			
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    	}
    }
