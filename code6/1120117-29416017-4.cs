    private async Task<List<Product>> InsertProductBatch(IEnumerable<Product> products, ulong merchantaccountid)
            {
                // Create a batch request.
                BatchRequest request = new BatchRequest(service);
    
                List<Product> responseproducts = new List<Product>();
    
                foreach (var p in products)
                {
                    ProductsResource.InsertRequest insertRequest =
                        service.Products.Insert(p, merchantaccountid);
                    request.Queue<Product>(
                             insertRequest,
                             (content, error, index, message) =>
                             {
       
                                 responseproducts.Add(content);
                                 //ResponseProducts.Add(content);
    
                                 if (content != null)
                                 {
                                     //product inserted successfully
                                 }
                                 AppendLine(String.Format("Product inserted with id {0}", ((Product)content).Id));
    
                                 if (error != null)
                                 {
                                     //there is an error you can access the error message though error.Message
                                 }
                                 
                             });
                                 
                }
                
                await request.ExecuteAsync(CancellationToken.None);
                return responseproducts;
            }
