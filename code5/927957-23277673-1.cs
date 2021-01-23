     var articles = 
        (from a in am.Article
         .Include(article=>article.UserProfile) //!!
         where (a.CultureName == calture || a.CultureName == 0)
             && a.IsApproved == status
             && a.IsPublished == status
         orderby a.AddedDate descending
         select a).ToList();
   
    //no more DB calls in foreach loop
    this.gvArticles.DataSource = articles.ToList();
    this.gvArticles.DataBind();
