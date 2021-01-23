        private void SearchBoxEventsSuggestionsRequested(object sender, SearchBoxSuggestionsRequestedEventArgs e)
        {
            string queryText = e.QueryText;
            if (!string.IsNullOrEmpty(queryText))
            {
                Windows.ApplicationModel.Search.SearchSuggestionCollection suggestionCollection = e.Request.SearchSuggestionCollection;
                foreach (string suggestion in SuggestionList)
                {
                    if (suggestion.StartsWith(queryText, StringComparison.CurrentCultureIgnoreCase))
                    {
                        suggestionCollection.AppendQuerySuggestion(suggestion);
                    }
                }
            }
         }
