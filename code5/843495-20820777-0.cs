    /// <summary>
    /// Deprecated Method for adding a new object to the Products EntitySet.
    /// Consider using the .Add method of associated ObjectSet<T> property instead.
    /// </summary>
    public void AddToProducts(Product product)
    {
        base.AddObject("Products", product);
    }
