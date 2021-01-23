        private static void HandleApplicationOnlyAuthentication()
        {
            var auth = new ApplicationOnlyAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"]
                }
            };
            auth.Authorize();
            //auth.Invalidate();
            var twitterCtx = new TwitterContext(auth);
            var srch =
                (from search in twitterCtx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == "LINQ to Twitter"
                 select search)
                .SingleOrDefault();
            Console.WriteLine("\nQuery: {0}\n", srch.SearchMetaData.Query);
            srch.Statuses.ForEach(entry =>
                Console.WriteLine(
                    "ID: {0, -15}, Source: {1}\nContent: {2}\n",
                    entry.StatusID, entry.Source, entry.Text));
        }
