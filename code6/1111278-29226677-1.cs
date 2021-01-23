    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string url1 = "https://fbcdn-creative-a.akamaihd.net/hads-ak-xaf1/t45.1600-4/s110x80/10156615_6017073002888_1171145694_n.png";
    		string url2 = "https://fbcdn-creative-a.akamaihd.net/hads-ak-xaf1/t45.1600-4/10156615_6017073002888_1171145694_n.png";
    		
    		Regex reg = new Regex("s\\d+x\\d+/");
    		
    		Console.WriteLine(reg.Replace(url1, ""));
    		Console.WriteLine(reg.Replace(url2, ""));
    	}
    }
