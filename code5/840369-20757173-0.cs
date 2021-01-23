    [Test]
    public void SelectProductAndCategoryColumns()
    {
        var result = _context.Products
            .Where(x => x.ProductID == 1)
            .Select(x => new { x.ProductID, x.Category.CategoryID, x.Category.CategoryName })
            .Single();
        Assert.AreEqual(1, result.ProductID);
        Assert.AreNotEqual(0, result.CategoryID);
        Assert.IsNotNull(0, result.CategoryName);
    }
