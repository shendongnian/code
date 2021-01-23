    public List<vwArticle> GetArticlesByAnalyst(string user)
        {
            List<vwArticle> ArticlesByAnyalist = new List<vwArticle>();
            var query = from a in _Context.fnarticles(user)
                        select a;
            foreach (var a in query)
            {
                var article = new vwArticle
                {
                    ArticleId = a.ArticleId,
                    ArticleTitle = a.ArticleTitle,
                    Country = a.Country,                   
                    userUpdated = a.userUpdated,
                    userCreated = a.userCreated,
                    dateCreated = a.dateCreated,
                    dateUpdated = a.dateUpdated,
                    versionDate = a.versionDate    
                };
                ArticlesByAnyalist.Add(article);
            }
            return ArticlesByAnyalist;
        }
