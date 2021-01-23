    using System;
    using System.Diagnostics;
    					
    public class Program
    {
    	
    	
    	const int MAX_ITERATIONS = 10000000;
    	const int MAX_SIZE = 1000;
    	
    	
    	public static void Main()
    	{
    		
    			var timer = new Stopwatch();
    			
    			Random rand = new Random();
    			long InRange = 0;
    			long OutOfRange = 0;
    			timer.Start();
    			for ( int i = 0; i < MAX_ITERATIONS; i++ ) {
    				var x = rand.Next( MAX_SIZE * 2 ) - MAX_SIZE;
    				if ( x < 0 || x > MAX_SIZE ) {
    					OutOfRange++;
    				} else {
    					InRange++;
    				}
    			}
    			timer.Stop();
    			Console.WriteLine( "Comparision 1: " + InRange + "/" + OutOfRange + ", elapsed: " + timer.ElapsedMilliseconds + "ms" );
    			rand = new Random();
    			InRange = 0;
    			OutOfRange = 0;
    			timer.Reset();
    			timer.Start();
    			for ( int i = 0; i < MAX_ITERATIONS; i++ ) {
    				var x = rand.Next( MAX_SIZE * 2 ) - MAX_SIZE;
    				if ( (uint) x > (uint) MAX_SIZE ) {
    					OutOfRange++;
    				} else {
    					InRange++;
    				}
    			}
    			timer.Stop();
    			
    			Console.WriteLine( "Comparision 2: " + InRange + "/" + OutOfRange + ", elapsed: " + timer.ElapsedMilliseconds + "ms" );
    	}
    }
