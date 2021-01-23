    var dict = new Dictionary<Category, List<Item>>();
    foreach (var item in ItemsList)
    {
        AddToCategory(item, item.mainCat);
        foreach (var cat in item.RelatedCategories)
        {
            AddToCategory(item, cat);
        }
    }
    void AddToCategory(Item item, Category cat)
    {
        List<Item> categoryItems;
        if (!dict.TryGetValue(cat, out categoryItems))
        {
            categoryItems = new List<Item>();
            dict.Add(cat, categoryItems);
        }
        categoryItems.Add(item);
    }
