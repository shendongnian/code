    using (SqlCommand addProduct = new SqlCommand("INSERT INTO dbo.Test VALUES(@ProductName);", sqlConnect);
    {
       addProduct.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50).Value = txtProductName.Text;
       addProduct.ExecuteNonQuery();
       MessageBox.Show("This product has been succesfully added to the database!!");
    }
