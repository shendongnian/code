     foreach (var product in ListofAllProducts)
            {
                if (i == 1)
                {
                    if (Product.ProductName== productname)
                    {
                        return product;
                    }
                }
                else
                {
                    foreach (var product in ListofAllProducts)
                    {
                        if (int.Parse(product .CustomerID)==0)
                        {
                            return product ;
                        }
                    }
                  
                    return tempproducts[0];
                }
            }
            return null;           
        }
