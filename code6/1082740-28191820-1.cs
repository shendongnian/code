    using (EFTestingEntities efso = new EFTestingEntities())
    {
        Article article1 = new Article();
    	article1.description = "hello";
    
    	Article article2 = new Article();
    	article2.description = "world";
    
    	efso.Article.Add(article1);
    	efso.Article.Add(article2);
    
    	article1.Article2.Add(article2);
    	article2.Article1.Add(article1);
    
    	efso.SaveChanges();
    }
