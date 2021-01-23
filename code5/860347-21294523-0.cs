    if (NavigationContext.QueryString.ContainsKey("count"))
            {
                var countString = NavigationContext.QueryString["count"];
                var count = Int32.Parse(countString);
                // Create list
                for(int i = 0; i < count; i++) 
                {
                     MyLLSList.Add(new Item());
                }
            }
