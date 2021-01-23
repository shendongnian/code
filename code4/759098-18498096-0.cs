    public NewCategories ConvertToNewCategories(Categories cat){
      NewCategories nc = new NewCategories {Id = cat.CategoryId, Name = cat.CategoryName};
      nc.SubCategories.AddRange(cat.Categories1.Select(c=>ConvertToNewCategories(c)));
      return nc;
    }
    //Then
    List<NewCategories> categories = db.Categories.Where(item => item.RelatedId == null)
                                                  .Select(item=>ConvertToNewCategories(item))
                                                  .ToList();
