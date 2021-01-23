    using System.Text.RegularExpressions;
    
        Regex rgx = new Regex("\d+\s+\d{1,2}/(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)/[12]\d{3}\s+\d{2}:\d{2}:\d{2}\s+\d+\s+\d{2}:\d{2}\s+\d+.\d+\s+\*\*");
        if (rgx.IsMatch(line))
        {
        	string[] split = line.Split(new Char[] { ' ' });
        	//process your data, etc
        }
