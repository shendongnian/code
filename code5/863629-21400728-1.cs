     public static List<Product> GetProductsBasedOnInputFilters(List<Product> productList, List<Specification<Product>> productSpecifications)
     {
                IEnumerable<Product> selectedList = productList;
                foreach (Specification<Product> specification in productSpecifications)
                {
                    selectedList = selectedList.Where(specification.IsSatisfiedBy);
                }
                return selectedList.ToList();
     }
