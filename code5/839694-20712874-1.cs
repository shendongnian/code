    var conString="Replace your connection string here";
    using (var conn =   new SqlConnection(conString))
    {
        conn.Open();
        string qry = "SELECT P.ID,P.ProductName,P.ProductCategoryID,C.ID,
                      C.CategoryName from Product P  INNER JOIN   
                      Category C ON P.ProductCategoryID=C.ID";
        var products = conn.Query<Product, Category, Product>
                         (qry, (prod, cat) => { prod.Category = cat; return prod; });
    
        foreach (Product product in products)
        {
            //do something with the products now as you like.
        }
        conn.Close(); 
    }
