     string text = fctb.Text;
     string strRegex = @"(\*\*\* (.*?)(?=\*\*\* |\z))";                      // ANSWER #1 
     //string strRegex = @"(\*\*\* [^\*]+AGPRSKeysAssocEnum.*?)(?=\*\*\*|\z)"; // ANSWER #2
     Regex myRegex = new Regex(strRegex, RegexOptions.Singleline);
     MatchCollection m = myRegex.Matches(text);
     foreach (Match sm in m)
     {
     	System.Diagnostics.Debug.WriteLine(sm.Groups[1].Value);
     	System.Diagnostics.Debug.WriteLine(new String('-', 100));
     }
