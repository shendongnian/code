        Product NewList = new Product();
        private void AddNewItems()
        {
            NewList.data = new List<Product.Subcategory>();
            foreach (var subcat in OriginalList.data)
            {
                if (!NewList.data.Any(c => c.category_id == subcat.category_id))
                {
                    NewList.data.Add(subcat);
                }
            }
            Product tempList = Product.DeepCopy(NewList);
            foreach (var cat in dicCategories)
            {
                foreach (var toAdd in cat.Value)
                {
                    if (toAdd.parent_category_id == 0)
                    {
                        //Root
                        if (!NewList.data.Any(c => c.category_id == toAdd.category_id))
                        {
                            tempList.data.Add(toAdd);
                        }
                    }
                    else
                    {
                        foreach (var subcat in OriginalList.data)
                        {
                            Product.Subcategory y = Product.FindSubCat(subcat, toAdd.parent_category_id);
                            if (y != null)
                            {
                                Product.Subcategory x = BrowseCategories(subcat, toAdd);
                                int index = NewList.data.IndexOf(subcat);
                                tempList.data[index] = x;
                            }
                        }
                    }
                }
            }
           
            NewList = tempList;
            foreach (var product in dicProducts)
            {
                
                foreach (var subcat in NewList.data)
                {
                    foreach (var subproduct in product.Value)
                    {
                        Product.Subcategory y = Product.FindSubCat(subcat, product.Key);
                        if (y != null)
                        {
                            Product.Subcategory x = BrowseProducts(subcat, subproduct, product.Key);
                            int index = NewList.data.IndexOf(subcat);
                            tempList.data[index] = x;
                            x = x;
                        }
                       
                        //tempList.data[subcat] =
                    }
                }
            }
            NewList = tempList;
        }
        private Product.Subcategory BrowseProducts(Product.Subcategory category, Product.ProductInfo toAdd, int catId)
        {
            try
            {
                if (category.category_id == catId)
                {
                    if (category.products == null) category.products = new List<Product.ProductInfo>();
                    var remove = category.products.SingleOrDefault(s => s.id == toAdd.id);
                    if (remove != null)
                    {
                        if (remove.id != 0)
                        {
                            category.products.Remove(remove);
                        }
                    }
                    category.products.Add(toAdd);
                    return category;
                }
                if (category.products == null) return category;
                if (category.subcategories == null) return category;
                foreach (var cat in category.subcategories)
                {
                    if (cat.category_id == catId)
                    {
                        if (cat.products == null) cat.products = new List<Product.ProductInfo>();
                        var remove = cat.products.SingleOrDefault(s => s.id == toAdd.id);
                        if (remove != null)
                        {
                            if (remove.id != 0)
                            {
                                cat.products.Remove(remove);
                            }
                        }
                        cat.products.Add(toAdd);
                        return category;
                    }
                    BrowseProducts(cat, toAdd, catId);
                }
                return category;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        private Product.Subcategory BrowseCategories(Product.Subcategory category, Product.Subcategory toAdd)
        {
            try
            {
                if (category.category_id == toAdd.parent_category_id)
                {
                    if (category.subcategories == null) category.subcategories = new List<Product.Subcategory>();
                    var remove = category.subcategories.SingleOrDefault(s => s.category_id == toAdd.category_id);
                    if (remove != null)
                    {
                        if (remove.category_id != 0)
                        {
                            category.subcategories.Remove(remove);
                        }
                    }
                    category.subcategories.Add(toAdd);
                    return category;
                }
                if (category.subcategories == null) return category;
                foreach (var cat in category.subcategories)
                {
                    if (cat.category_id == toAdd.parent_category_id)
                    {
                        if (cat.subcategories == null) cat.subcategories = new List<Product.Subcategory>();
                        var remove = cat.subcategories.SingleOrDefault(s => s.category_id == toAdd.category_id);
                        if (remove != null)
                        {
                            if (remove.category_id != 0)
                            {
                                cat.subcategories.Remove(remove);
                            }
                        }
                        cat.subcategories.Add(toAdd);
                        return category;
                    }
                    BrowseCategories(cat, toAdd);
                }
                return category;
            }
            catch (Exception)
            {
                    
                throw;
            }
          
        } 
