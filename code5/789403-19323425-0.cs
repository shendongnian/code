    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    
    public class Test
    {
        public static void Main()
        {
            OrderedDictionary Links = new OrderedDictionary();
            Links.Add("Learn more about adding manuals and labels", "2");
            Links.Add("Delete Manuals and Labels", "3");
            Links.Add("manuals and labels", "1");
            
            string text = "Having trouble with your manuals and labels? Learn more about adding manuals and labels. Need to get rid of them? Try to delete manuals and labels.";
    
    	    foreach (string termToFind in Links.Keys)
    	    {
    	        Regex _regex = new Regex(@"\b" + termToFind + @"s?\b(?![^<>]*</)", RegexOptions.IgnoreCase);
    	        text = _regex.Replace(text, @"<a href=""" + Links[termToFind] + @".html"">$&</a>");
    	    }
    	    Console.WriteLine(text);
        }
    }
