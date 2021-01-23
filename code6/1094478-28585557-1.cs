        public List<vwArticle> GetArticles(string filter)
        {
          var ArticlesByAnalyst = GetArticlesByAnalyst("GEMMA");
          var query = from a in ArticlesByAnalyst 
                      where blah blah                        
                      select a;
              
          return query.ToList();  
        }
