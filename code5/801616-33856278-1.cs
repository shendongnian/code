    IEnumerable<Category> mlc = GenerateTree(c => c.Id, 
                                             c.ParentId,
                                             (c, ci) => new Category
                                             {
                                                  Id = c.Id,
                                                  Subcategories = ci
                                             });
