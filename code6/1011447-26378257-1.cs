            public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(connString))
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT dbo.Products.ProductID, dbo.Vendors.Name AS VendorName, dbo.Products.Name AS ProductName ");
                query.Append("FROM dbo.Products ");
                query.Append("INNER JOIN dbo.Vendors ON dbo.Products.VendorID = dbo.Vendors.VendorID");
                connection.Open();
                using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                {
                    command.Notification = null;
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new Product { ProductID = (long)reader["ProductID"], VendorName = (string)reader["VendorName"], Name = (string)reader["ProductName"] });
                    }
                }
            }
            return products;
        }
