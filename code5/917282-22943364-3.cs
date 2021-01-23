    public string GetCategoryName(Int32 albumCategoryId)
    {
       using (var _db = new Trying.Models.AlbumContext())
       {
           var category = _db.Categories.SingleOrDefault(c.id == albumCategoryId);
           if (category != null)
           {
              return category.Name;
           }
           else
           {
              // Handle the no category found case by returning a default value,
              // throwing an exception or what ever fits your needs.
           }
       }
    }
