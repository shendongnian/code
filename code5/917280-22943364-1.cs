    public string GetCategoryName(int albumCategoryId)
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
              // Handle no category found by returning a default value,
              // throwing an exception or what ever fits your needs.
           }
       }
    }
