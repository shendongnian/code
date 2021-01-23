    public static IEnumerable<ProductCategoryModel> ToModel(
        this IQueryable<ProductCategory> query)
    {
        return query.Select(p => new
                            {
                              Children = p.Childs
                                          .Select(ch => new ChildModel()
                                                  { 
                                                    Grandchild = ch.Grandchild.Code
                                                  })
                            })
                    .AsEnumerable()
                    .Select(x => new ParentModel { Children = x.Children.ToList() })
                    .ToList();
    }
