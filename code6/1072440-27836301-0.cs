    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string str ="name1|10|junk data.....\nname2|9|junk data.....\nname3|8|junkdata.....\nname4|7|junk data.....";
    			
    		foreach (var line in str.Split('\n'))
    		{
    			Console.WriteLine(line.Split('|')[0]);	
    		}
    	}
    }
