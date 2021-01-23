    using System;
    using System.Linq;
    
    public static class StringExtensions
    {
    	/// <summary>
    	/// Converts a string to PascalCase
    	/// </summary>
    	/// <param name="str">String to convert</param>
    
    	public static string ToPascalCase(this string str){
    		
    		// Replace all non-letter and non-digits with an underscore and lowercase the rest.
    		string sample = string.Join("", str?.Select(c => Char.IsLetterOrDigit(c) ? c.ToString().ToLower() : "_").ToArray());
    		
    		// Split the resulting string by underscore
    		// Select first character, uppercase it and concatenate with the rest of the string
    		var arr = sample?
    			.Split(new []{'_'}, StringSplitOptions.RemoveEmptyEntries)
    			.Select(s => $"{s.Substring(0, 1).ToUpper()}{s.Substring(1)}");
    		
    		// Join the resulting collection
    		sample = string.Join("", arr);
    		
    		return sample;
    	}
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("WARD_VS_VITAL_SIGNS".ToPascalCase()); // WardVsVitalSigns
    		Console.WriteLine("Who am I?".ToPascalCase()); // WhoAmI
    		Console.WriteLine("I ate before you got here".ToPascalCase()); // IAteBeforeYouGotHere
    		Console.WriteLine("Hello|Who|Am|I?".ToPascalCase()); // HelloWhoAmI
    		Console.WriteLine("Live long and prosper".ToPascalCase()); // LiveLongAndProsper
    		Console.WriteLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit.".ToPascalCase()); // LoremIpsumDolorSitAmetConsecteturAdipiscingElit
    	}
    }
