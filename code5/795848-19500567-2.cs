    public List<Prodict> getProducts()
    {
        SqlConnection connection = new SqlConnection( "Data Source=111111;Initial Catalog=11111;User ID=111111;Password=11111");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT productId, productName, location FROM Products", connection);
				
		var productList = new List<Product>(); //Do Array, if it is better for you.
		using(SqlDataReader rdr = cmd.ExecuteReader())
		{
			while (rdr.Read())
			{
				var product = new Product(rdr.GetValue(0).ToString(),rdr.GetValue(1).ToString(),rdr.GetValue(2).ToString());
				productList.Add(product);
			}
		}
	    return productList;
    }
