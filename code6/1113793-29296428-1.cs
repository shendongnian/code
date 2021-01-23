     [Fact]
    public async Task ExpandOne()
    {
    var product = (await _client
      .For<Product>()
      .OrderBy(x => x.ProductID)
      .Expand(x => x.Category)
      .FindEntriesAsync()).Last();
    Assert.Equal("Condiments", product.Category.CategoryName);
    }
    [Fact]
    public async Task ExpandManyAsArray()
    {
    var category = await _client
      .For<Category>()
      .Expand(x => x.Products)
      .Filter(x => x.CategoryName == "Beverages")
      .FindEntryAsync();
    Assert.Equal(12, category.Products.Count());
    }
    [Fact]
    public async Task ExpandManyAsList()
    {
    var category = await _client
      .For<CategoryWithList>("Categories")
      .Expand(x => x.Products)
      .Filter(x => x.CategoryName == "Beverages")
      .FindEntryAsync();
    Assert.Equal(12, category.Products.Count());
    }
    [Fact]
    public async Task ExpandManyAsIList()
    {
    var category = await _client
      .For<CategoryWithIList>("Categories")
      .Expand(x => x.Products)
      .Filter(x => x.CategoryName == "Beverages")
      .FindEntryAsync();
    Assert.Equal(12, category.Products.Count());
    }
    [Fact]
    public async Task ExpandManyAsICollection()
    {
    var category = await _client
      .For<CategoryWithICollection>("Categories")
      .Expand(x => x.Products)
      .Filter(x => x.CategoryName == "Beverages")
      .FindEntryAsync();
    Assert.Equal(12, category.Products.Count());
    }
    [Fact]
    public async Task ExpandSecondLevel()
    {
    var product = (await _client
      .For<Product>()
      .OrderBy(x => x.ProductID)
      .Expand(x => x.Category.Products)
      .FindEntriesAsync()).Last();
    Assert.Equal(12, product.Category.Products.Length);
    }
