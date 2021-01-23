    var dict = new Dictionary<string, Category>
    {
        { "Animals", new Category
            {
                name = "Animals",
                data = new List<List<object>>
                {
                    new List<object> { "Cows", 2 },
                    new List<object> { "Sheep", 3 }
                }
            }
        },
    };
    string serialized = JsonConvert.SerializeObject(dict, Formatting.Indented);
