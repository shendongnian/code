        using (SearchResultCollection results = searcher.FindAll())
        {
            TextBoxSearch.Text = "No match found";
            foreach (SearchResult result in results)
            {
                string name = (string)result.Properties["samaccountname"][0];
                if (name == TextBoxSearch.Text)
                {
                    TextBoxSearch.Text = name;
                    break;
                }
            }
        }
