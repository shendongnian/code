    [Fact]
    public async Task ExpandOne()
    {
    var product = (await _client
      .For("Products")
      .OrderBy("ProductID")
      .Expand("Category")
      .FindEntriesAsync()).Last();
    Assert.Equal("Condiments", (product["Category"] as IDictionary<string, object>)["CategoryName"]);
    }
    [Fact]
    public async Task ExpandMany()
    {
    var category = await _client
      .For("Categories")
      .Expand("Products")
      .Filter("CategoryName eq 'Beverages'")
      .FindEntryAsync();
    Assert.Equal(12, (category["Products"] as IEnumerable<object>).Count());
    }
    [Fact]
    public async Task ExpandSecondLevel()
    {
    var product = (await _client
      .For("Products")
      .OrderBy("ProductID")
      .Expand("Category/Products")
      .FindEntriesAsync()).Last();
    Assert.Equal(12, ((product["Category"] as IDictionary<string, object>)["Products"] as IEnumerable<object>).Count());
    }
