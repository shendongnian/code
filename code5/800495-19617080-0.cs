    public void InsertArticle(Article entity)
    {
        entity.Author = this.dataContext.Authors.Find(entity.AuthorEntityIdPropertyName);
        this.dataSet.Add(entity);
        this.dataContext.SaveChanges(); //<-- 
    }
