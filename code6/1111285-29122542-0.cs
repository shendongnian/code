    string text = "Your log text";
                IEnumerable<string> splittedLog = GetEntriesForLog(text);
                string strRegex = @".*?AGPRSKeysAssocEnum.*|\z";
                Regex myRegex = new Regex(strRegex, RegexOptions.ExplicitCapture | RegexOptions.Singleline);
    
                var entries = splittedLog.Where(entry => myRegex.IsMatch(entry)).ToList();
