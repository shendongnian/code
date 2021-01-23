             public List<Product> GetProductList() 
             {
                        //sqlConnect.Open();
                        SqlDataReader dr4 = searchProduct.ExecuteReader();
                        List <Product> products = new List<Product>();
                        //your method should return products
                        if (dr4.HasRows)
                        {
                           
                            while (dr4.Read())
                            {
                                 Product myP = new Product();
                                 myP.ProductName = dr4["ProductName"].ToString() + " ";
                                 myP.Cost = dr4["Cost"].ToString() + " ";
                                 Products.Add(myP);
                                
                            }
                        }
                        dr4.Close();
                       
                         return products;
                   
          }
