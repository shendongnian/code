     public static List<Product> GetProductsUisngDynamicFilters(List<Product> productList, Specification<Product> productSpecification)
        {
            return productList.Where(p => productSpecification.IsSatisfiedBy(p))
                              .ToList();
        }
