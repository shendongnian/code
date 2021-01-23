    var query = from product in cse.tblTransactionItems
                group product by new
                {
                    product.tblProduct.Description,
                    product.tblProduct.Customer // put the customer here.
                } into g
                select new
                {
                    Product = g.Key.Description,
                    Customer = g.Key.Customer,
                    totalUnitsSold = g.Count()
                }; 
