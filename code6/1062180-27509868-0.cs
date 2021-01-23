    using System;
    
    namespace TestThrowExceptionInProperty
    {
    	class Thrower {
    		public int CheckMe {get{ throw new NotImplementedException (); }}
    	}
    
    	class MainClass
    	{
    	
    		public static void Main (string[] args)
    		{
    			var thrower = new Thrower ();
    			int bye = thrower.CheckMe;
    			Console.WriteLine(bye);
    		}
    	}
    }
