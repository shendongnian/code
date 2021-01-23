        private List<Product.Subcategory> UpdateObjects(List<Product.Subcategory> prod)
        {
            try
            {
                int catcount = prod.Count;
                if (catcount > 0)
                {
                    for (int i = catcount - 1; i > -1; i--)
                    {
                        //if (prod[i].category_id == 203)
                        //{
                        //    Debug.WriteLine("");
                        //}
                        try
                        {
                            //Check if exists
                            if (categories.All(u => u.id != prod[i].category_id))
                            {
                                //if (prod[i].category_id == 203)
                                //{
                                //    prod.RemoveAt(i);
                                //}
                                if (!dicCategories.ContainsKey(prod[i].category_id))
                                {
                                    prod.RemoveAt(i);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        foreach (var newsubCat in generatedSubcategories)
                        {
                            if (prod[i].category_id == newsubCat.category_id)
                            {
                                prod[i].delivery_time = newsubCat.delivery_time;
                                prod[i].image = newsubCat.image;
                                prod[i].name = newsubCat.name;
                                prod[i].pickup_time = newsubCat.delivery_time;
                                prod[i].sequence = newsubCat.sequence;
                                prod[i].translation_missing = newsubCat.translation_missing;
                                prod[i].use_firm_time_settings = newsubCat.use_firm_time_settings;
                            }
                        }
                        if (prod[i].products != null)
                        {
                            foreach (var oldProduct in prod[i].products)
                            {
                                int count = generatedProducts.Count;
                                if (count != 0)
                                {
                                    for (int z = count - 1; i > -1; i--)
                                    {
                                        try
                                        {
                                            //Check if exists
                                            if (products.All(u => u.id != generatedProducts[z].id))
                                            {
                                                generatedProducts.RemoveAt(z);
                                            }
                                            else
                                            {
                                                if (oldProduct.id == generatedProducts[z].id)
                                                {
                                                    oldProduct.amount = generatedProducts[z].amount;
                                                    oldProduct.comment = generatedProducts[z].comment;
                                                    oldProduct.delivery_time = generatedProducts[z].delivery_time;
                                                    oldProduct.description = generatedProducts[z].description;
                                                    oldProduct.image = generatedProducts[z].image;
                                                    oldProduct.ingredients = generatedProducts[z].ingredients;
                                                    oldProduct.name = generatedProducts[z].name;
                                                    oldProduct.pickup_time = generatedProducts[z].pickup_time;
                                                    oldProduct.price = generatedProducts[z].price;
                                                    oldProduct.sequence = generatedProducts[z].sequence;
                                                    oldProduct.times = generatedProducts[z].times;
                                                    oldProduct.translation_missing = generatedProducts[z].translation_missing;
                                                    oldProduct.unit = generatedProducts[z].unit;
                                                    oldProduct.use_category_time_settings = generatedProducts[z].use_category_time_settings;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            //throw;
                                        }
                                    }
                                }
                            }
                            if (prod[i].subcategories != null)
                            {
                                UpdateObjects(prod[i].subcategories);
                            }
                        }
                    }
                } 
            }
            catch (Exception)
            {
                //throw;
            }
            return prod;
        }
