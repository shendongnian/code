    public enum Category {
        Fruit,
        Dairy,
        Vegetable,
        Electronics
    }
    public enum Subcategory {
        [SubcategoryOf(Category.Fruit)]
        Apple,
        [SubcategoryOf(Category.Dairy)]
        Buttermilk,
        [SubcategoryOf(Category.Dairy)]
        Emmenthaler,
        [SubcategoryOf(Category.Fruit)]
        Orange,
        [SubcategoryOf(Category.Electronics)]
        Mp3Player
    }
