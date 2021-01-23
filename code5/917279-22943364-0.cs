    public string GetCategoryName(int albumCategoryId)
    {
       using (var _db = new Trying.Models.AlbumContext())
       {
           return _db.Categories.Single(c.id == albumCategoryId).Name;
       }
    }
