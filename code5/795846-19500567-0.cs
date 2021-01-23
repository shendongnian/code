	var productList = new List<Product>();
	using(SqlDataReader rdr = cmd.ExecuteReader())
	{
		while (rdr.Read())
		{
            var product = New Product(rdr.GetValue(0).ToString(),rdr.GetValue(1).ToString(),rdr.GetValue(2).ToString());
            productList.Add(product);
		}
	}
	return productList;
