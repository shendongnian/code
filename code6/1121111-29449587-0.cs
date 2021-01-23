    var results = context.Products
            .Include("ProductSubcategory")
            .Where(p => p.Name.Contains(searchTerm)
                        && p.DiscontinuedDate == null)
            .Select(p => new
                            {
                                p.ProductID,
                                ProductSubcategoryName = p.ProductSubcategory.Name,
                                p.Name,
                                p.StandardCost
                            })
            .AsEnumerable()
            .Select(p => new AutoCompleteData
                                {
                                    Id = p.ProductID,
                                    Text = BuildAutoCompleteText(p.Name,
                                        p.ProductSubcategoryName, p.StandardCost)
                                })
            .ToArray();
