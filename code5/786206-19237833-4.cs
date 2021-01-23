    private List<Product> LoadProducts(List<string> ids)
    {
        System.Linq.Expressions.Expression<Func<Product, Guid>> function = b => b.Id;
        return _productsRepository.Execute(
            new ProductsInformationQuery<Product, Guid>
               (ids, FeaturedIdType.ProductId, function))
           .ToList();
    }
