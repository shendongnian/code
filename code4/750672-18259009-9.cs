        SqlCommand sqlCmdProducts = new SqlCommand("SELECT * FROM TblProduct", myConnection);
    SqlDataReader productReader = sqlCmdProducts.ExecuteReader();
    while (productReader.Read()) {
        MyProductTypes.Add(new ProductType() {
        ProductTypeID = Int32.Parse(productReader["ProductType"].ToString()),
        Description = Int32.Parse(productReader["Description"].ToString()),
        };
    }
    SqlCommand sqlCmdProductType = new SqlCommand("SELECT * FROM TblProductType", myConnection);
    SqlDataReader productTypeReader = sqlCmdProductType.ExecuteReader();
    while (productTypeReader.Read()) {
        MyProducts.Add(new Product() {
        ProductID = Int32.Parse(productTypeReader["ProductID"].ToString()),
        ProductType = Int32.Parse(productTypeReader["ProductType"].ToString()),
        Description = productTypeReader["Description"].ToString()),
        Price = double.Parse(productTypeReader["Price"].ToString()),
        };
    }
