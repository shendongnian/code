    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Reflection;
    public class Test
    {
    	public static void Main()
    	{
    		string formatString = "{firstName} {lastName} is awesome.";
    		
    		Console.WriteLine(formatString.FormatUnicorn(new {
    			firstName = "joe",
    			lastName = "blow"
    		}));
    	}
    }
    
    public static class StringExtensions {
    	public static string FormatUnicorn(this string str, object arguments) {
    		string output = str;
    
            Type type = arguments.GetType();
    
            foreach (PropertyInfo property in type.GetProperties())
            {
                Regex regex = new Regex(@"\{" + property.Name + @"\}");
                output = regex.Replace(output, property.GetValue(arguments, null).ToString());
            }
    
            return output;
    	}
    }
