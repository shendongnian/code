    IEnumerable<Category> mlc = GenerateTree(categories,
                                             c => c.Id, 
                                             c => c.ParentId,
                                             (c, ci) => new Category
                                             {
                                                  Id = c.Id,
                                                  Name = c.Name,
                                                  ParentId = c.ParentId ,
                                                  Subcategories = ci
                                             });
