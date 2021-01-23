    public List<Product> SelectAllProducts()
    {
        using (IDbConnection connection = new SqlConnection(LOCAL))
        {
            string query = @"SELECT * FROM PRODUCTS ORDER BY Name";
            return connection.Query<Product>(query, null).ToList();
        }
    }
