        List<Product.ProductInfo> generatedProducts = new List<Product.ProductInfo>();
        List<Product.Subcategory> generatedSubcategories = new List<Product.Subcategory>();
        Dictionary<int, List<Product.Subcategory>> dicCategories = new Dictionary<int, List<Product.Subcategory>>();
        Dictionary<int, List<Product.ProductInfo>> dicProducts = new Dictionary<int, List<Product.ProductInfo>>();
        private List<Product.Subcategory> GenerateProductList(List<Product.Subcategory> prod, int parentCategoryId)
        {
            foreach (var subcategory in prod)
            {
                generatedSubcategories.Add(subcategory);
                if (dicCategories.ContainsKey(subcategory.category_id))
                {
                    //Add to value
                    subcategory.parent_category_id = parentCategoryId;
                    dicCategories[subcategory.category_id].Add(subcategory);
                }
                else
                {
                    subcategory.parent_category_id = parentCategoryId;
                    dicCategories.Add(subcategory.category_id, new List<Product.Subcategory> { subcategory });
                }
                if (subcategory.products != null)
                {
                    foreach (var product in subcategory.products)
                    {
                        generatedProducts.Add(product);
                        if (dicProducts.ContainsKey(subcategory.category_id))
                        {
                            //Add to value
                            dicProducts[subcategory.category_id].Add(product);
                        }
                        else
                        {
                            dicProducts.Add(subcategory.category_id, new List<Product.ProductInfo>{ product });
                        }
                    } 
                }
                if (subcategory.subcategories != null)
                {
                    GenerateProductList(subcategory.subcategories, subcategory.category_id);
                }
            }
            return prod;
        }
