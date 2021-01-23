    var model = new CategoryModel
    {
        Id = 1,
        Name = "Some Name",
        Posts = new List<Post>
        {
            new Post() {
                SomeProperty = "Some Property"
            },
            new Post() {
                SomeProperty = "Some Property"
            }
        }
    };
