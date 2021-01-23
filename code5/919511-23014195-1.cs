    List<SuggestionList> SuggestResultSet = new List<SuggestionList>();
    if(completionResults != null)
    {
        foreach(var suggestion in completionResults.Suggest)
        {
            SuggestsResultSet.Add(new SuggestionList {Text = suggestion.Text });
        }
    }
    
