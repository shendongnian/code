        bool matchfound= false;
        using (SearchResultCollection results = searcher.FindAll())
        {
            foreach (SearchResult result in results)
            {
                string name = (string)result.Properties["samaccountname"][0];
                if (name == TextBoxSearch.Text)
                {
                    TextBoxSearch.Text = name;
                    matchfound =true;
                    break;
                }
            }
        }
        if(!matchfound)
            TextBoxSearch.Text = "No match found";
        
