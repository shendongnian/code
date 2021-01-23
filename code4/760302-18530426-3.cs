        public class Product
        {
            public int Code { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
        public class ProductHandler
        {
            public ProductHandler(string connectionString)
            {
                ConnectionString = connectionString;
            }
            public bool AddProduct(Product product)
            {
                return AddProducts(new Product[] { product }) > 0;
            }
            public int AddProducts(IEnumerable<Product> products)
            {
                int rowsInserted = 0;
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO [Seranne] (Code, Description, Quantity) VALUES(@Code, @Description, @Quantity)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("Code", OleDbType.Integer);
                        cmd.Parameters.Add("Description", OleDbType.VarChar);
                        cmd.Parameters.Add("Quantity", OleDbType.Integer);
                        foreach (var product in products)
                        {
                            cmd.Parameters["Code"].Value = product.Code;
                            cmd.Parameters["Description"].Value = product.Description;
                            cmd.Parameters["Quantity"].Value = product.Quantity;
                            rowsInserted += cmd.ExecuteNonQuery();
                        }
                    }
                }
                return rowsInserted;
            }
            public bool UpdateProduct(Product product)
            {
                return UpdateProducts(new Product[] { product }) > 0;
            }
            public int UpdateProducts(IEnumerable<Product> products)
            {
                int rowsUpdated = 0;
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE [Seranne] SET Description = @Description, Quantity = @Quantity WHERE [Code] == @Code)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("Code", OleDbType.Integer);
                        cmd.Parameters.Add("Description", OleDbType.VarChar);
                        cmd.Parameters.Add("Quantity", OleDbType.Integer);
                        foreach (var product in products)
                        {
                            cmd.Parameters["Code"].Value = product.Code;
                            cmd.Parameters["Description"].Value = product.Description;
                            cmd.Parameters["Quantity"].Value = product.Quantity;
                            
                            rowsUpdated += cmd.ExecuteNonQuery();
                        }
                    }
                }
                return rowsUpdated;
            }
            public bool DeleteProduct(int productCode)
            {
                return DeleteProducts(new int[] { productCode }) > 0;
            }
            public int DeleteProducts(IEnumerable<int> productCodes)
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    string productCodeStr = string.Join(", ", productCodes);
                    string query = string.Format("DELETE FROM [Seranne] WHERE [Code] in ({0})", productCodeStr);
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        int rowsDeleted = cmd.ExecuteNonQuery();
                        return rowsDeleted;
                    }
                }
            }
            public IEnumerable<Product> ReadAllProducts()
            {
                List<Product> result = new List<Product>();
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT [Code], [Description], [Quantity] FROM [Seranne]", conn))
                    using (OleDbDataReader dReader = cmd.ExecuteReader())
                        while (dReader.Read())
                        {
                            Product product = new Product();
                            product.Code = Convert.ToInt32(dReader["Code"]);
                            product.Description = Convert.ToString(dReader["Description"]);
                            product.Quantity = Convert.ToInt32(dReader["Quantity"]);
                            result.Add(product);
                        }
                }
                return result;
            }
            public string ConnectionString { get; private set; }
        }
