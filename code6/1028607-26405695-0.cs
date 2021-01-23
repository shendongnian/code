    using System;
    using System.Text.RegularExpressions;		
    public class Program
    {
    	public static void Main()
    	{
    		// Your string
    		var formatedString = "<newNameSpace.HeresMyString>100000000000</newNameSpace.HeresMyString>";
    		formatedString = Regex.Replace( formatedString , "<.+HeresMyString>[0-14]+([0-14]{8})</.+HeresMyString>" , "<b.HeresMyString>****************$1</b.HeresMyString>" , RegexOptions.IgnoreCase );
    
    		
    		Console.WriteLine(formatedString);
    	}
    }
