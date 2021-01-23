    public static class DataProvider
    {
        private static T GetMatchingItem<T, K>(T[] SourceArray, K MatchingNode) 
            where T: AbstractNamedRemovableNode
            where K: AbstractNamedRemovableNode
        {
            if (SourceArray == null || SourceArray.Length == 0 || MatchingNode == null)
            {
                return null;
            }
            var query = from i in SourceArray
                        where !i.Remove && i.Equals(MatchingNode)
                        select i;
            return query.SingleOrDefault();
        }
        private static T[] CombineArray<T>(T[] sourceArray, T[] baseArray)
            where T : AbstractNamedRemovableNode, new()
        {
            IList<T> results = new List<T>();
            if (sourceArray != null)
            {
                foreach (var item in sourceArray)
                {
                    if (item.Remove)
                    {
                        continue;
                    }
                    T copy = default(T);
                    copy = item.CloneBasic<T>();
                    if (copy is Category)
                    {
                        Category category = copy as Category;
                        Category original = item as Category;
                        Category matching = GetMatchingItem(baseArray, item) as Category;
                        if (matching != null)
                        {
                            category.Issues = CombineArray(original.Issues, matching.Issues);
                        }
                        else
                        {
                            category.Issues = CombineArray(original.Issues, null);
                        }
                    }
                    results.Add(copy);
                }
            }
            if (baseArray != null)
            {
                foreach (var item in baseArray)
                {
                    if (results.Contains(item))
                    {
                        continue;
                    }
                    if (sourceArray != null && sourceArray.Contains(item))
                    {
                        // the remove option would have worked here
                        continue;
                    }
                    T copy = item as T;
                    if (copy is Category)
                    {
                        Category category = copy as Category;
                        Category original = item as Category;
                        category.Issues = CombineArray(original.Issues, null);
                    }
                    results.Add(copy);
                }
            }
            return results.OrderBy((item) => item.Name).ToArray();
        }
        public static Product[] GetCombinedProductInfoFromData(Data data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            IList<Product> products = new List<Product>();
            if (data.Products != null)
            {
                foreach (var originalProduct in data.Products)
                {
                    Product product = originalProduct.CloneBasic<Product>();
                    if (originalProduct.Categories != null && originalProduct.Categories.Length > 0)
                    {
                        product.Categories = CombineArray(originalProduct.Categories, data.Categories);
                    }
                    else
                    {
                        product.Categories = CombineArray(data.Categories, null);
                    }
                    products.Add(product);
                }
            }
            return products.ToArray();
        }
    }
