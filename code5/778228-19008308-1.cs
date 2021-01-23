    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		decimal d = 10;
            decimal result = d / 10;
            
    		Console.WriteLine( string.Format("{0:0.0}", result ) );
    		// or
    		Console.WriteLine( result.ToString("0.0") );
    	}
    }
