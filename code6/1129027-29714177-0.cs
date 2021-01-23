    using System;
    public class Test
    {
    	public static void Main()
    	{
    		String Str = "";
    		
    		for(int i =0;i<10;i++)
    		{
    			Str += i.ToString();
    		}
    		Console.WriteLine(Str);
    		System.IO.File.WriteAllText(@"C:\SaveInfo.Txt",Str);
    	}
    }
