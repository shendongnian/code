    var products = new List<Product>();
    using (SqlConnection sqlConnection = new SqlConnection(LOCAL))
    {
      sqlConnection.Open();
      using (SqlCommand cmd = sqlConnection.CreateCommand())
      {
       cmd.CommandText = "select Sku from product;
       cmd.CommandType = CommandType.Text;
       using (SqlDataReader reader = cmd.ExecuteReader()) ????
       {
        var product = new Product();
        //Grab the values using the SqlDataReader and map it to the properties
        //...
        //Add code e.g. product.Id = reader.GetField<int>("Id");
        //...
        products.Add(product);
       }
      }
    }
