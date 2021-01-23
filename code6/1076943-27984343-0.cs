    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var callbackUrl1 = new System.Uri("http://localhost:2757/index.html" +
                    "?load=email" +
                    "&userId=" + "12345££&^" +
                    "&code=" + "myCo   de");
    		
       
    		var aHref = string.Format("<a href=\'{0}'>link</a>", callbackUrl1.AbsoluteUri);
    
    		
    		Console.WriteLine(aHref);
    	}
    }
