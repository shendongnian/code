    private static void RecurseProductCategories(string[] categoryNames, List<Category> parentList, Category parent = null)
            {
                if (categoryNames.Length > 0)
                {
                    var catName = categoryNames[0].Trim();
                    var catObject = parentList.SingleOrDefault(f => f.Title == catName);
                    if (catObject == null)
                    {
                        catObject = new Category { Title = catName, Slug = catName.GenerateSlug(), Parent = parent };
                        parentList.Add(catObject);
                    }
    
                    RecurseProductCategories(categoryNames.Skip(1).ToArray(), catObject.Children, catObject);
                }
            }
