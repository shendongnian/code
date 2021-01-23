    post.PostMappings = current_list_category;
        
    List<PostMapping> temp = new List<PostMapping>();
    temp.AddRange(current_list_category);
    foreach (PostMapping pm in temp)
            {
                int categoryId = pm.CategoryID.Value;
                if (selectedCategories != null)
                {
                    if (selectedCategories.Contains(categoryId))
                    {
                        selectedCategories = selectedCategories.Where(val => val != categoryId).ToArray();
                    }
                    else
                    {
    
                        post.PostMappings.Remove(pm);
                        Category category = db.Categories.Where(c => c.ID == categoryId).SingleOrDefault();
                        category.PostMappings.Remove(pm);
                    }
                }
    
            }
