    public static CategoryModel From(Category data, bool deep = false)
    {
            return new CategoryModel()
            {
                Id = data.Id,
                Name = data.Name,
                Posts = data.Posts.Select(p => PostModel.From(p)).ToList()
            };
    }
