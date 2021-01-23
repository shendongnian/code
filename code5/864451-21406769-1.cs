    public static List<Product> GetProductsUisngAndFilters(List<Product> productList, Specification<Product> productSpecification)
    {
        return productList.Where(p => productSpecification.IsSatisfiedBy(p))
                          .ToList();
    }
