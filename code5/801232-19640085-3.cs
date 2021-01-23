    public static void Foo()
    {
        IQueryable<Product> products = null;
        var query = products.Where(
            SelectCurrent((Product p) => p.Translations)
            .Compose(translation => translation.Name.ToLower().Contains("abc")));
    }
