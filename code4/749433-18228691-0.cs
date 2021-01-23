    private IEnumerable<AutocompleteItem> BuildList()
    {
        //find all words of the text
        bool bolFindMatch = false;
        var words = new Dictionary<string, string>();
    
        var keysToBeFiltered = new HashSet<string> { "Do", "Not" };
        var filter = words.Where(p => !keysToBeFiltered.Contains(p.Key))
                          .ToDictionary(p => p.Key, p => p.Value);
    
        foreach (Match m in Regex.Matches(rtb1.Text, @"\b\w+\b"))
        {
            foreach (string hs in keysToBeFiltered)
            {
                if (Regex.Matches(m.Value, @"\b" + hs + @"\b").Count > 0)
                {
                    bolFindMatch = true;
                    break;
                }
            }
    
            if (!bolFindMatch)
            {
                filter[m.Value] = m.Value;
            }
            else
            {
                bolFindMatch = false;
            }
        }
    
        //foreach (Match m in Regex.Matches(rtb_JS.Text, @"^(\w+)([=<>!:]+)(\w+)$"))
            //filter[m.Value] = m.Value;
    
        foreach (var word in filter.Keys)
        {
            yield return new AutocompleteItem(word);
        }
    }
