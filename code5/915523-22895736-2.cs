    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> list = new List<string>() {"truc", "I love toto", "next", "chocolate", "tata tata", "", "something"};
    		WordsFilter(list);
    	}
    	
    	private static void WordsFilter(List<string> newText)
        {
    		string[] WordsList = new string[] { "toto", "tata" };
    		
        	for (int i = 0; i < newText.Count; i++)
        	{
    	        for (int x = 0; x < WordsList.Length; x++)
    	        {
    				if (newText[i].Contains(WordsList[x]))
        	        {
    	                newText.RemoveAt(i);
			          	if (i + 1 < newText.Count)
					        newText.RemoveAt(i);
        	        }
    	       	}
    	    }
		
    		// print
    		foreach(var item in newText)
    		{
    			Console.WriteLine(item);
    		}
    	}
    }
