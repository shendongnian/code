        string MultiReplace(string original, Dictionary<string, string> replacements)
        {
           //initialize result with original in case no replacements have been requested
           string result = original;
           foreach (var r in replacements)
           {
              result = result.Replace(r.Key, r.Value);
           }
           return result;
        }
