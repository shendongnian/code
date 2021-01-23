    string ConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\DATA2\Nescot Students\Y13\s0234438\dboCanada.accdb";
    using(OleDbConnection conn = new OleDbConnection(ConnString ))
    using(OleDbCommand cmd = conn.CreateCommand())
    {
       cmd.CommandText = @"UPDATE Products SET [Product_Name] = @ProName, [Product_Description] = @ProDes, [Standard_Cost] = @StaCos, [Category] = @Cat, [List_Price] = @LisPri  WHERE ID = @id";
       cmd.Parameters.AddWithValue("@ProName", txtProducts.Text);
       cmd.Parameters.AddWithValue("@ProDes", txtDescription.Text);
       cmd.Parameters.AddWithValue("@StaCos", Convert.ToDecimal(txtPrice.Text));
       cmd.Parameters.AddWithValue("@Cat", txtCat.Text);
       cmd.Parameters.AddWithValue("@LisPri", Convert.ToDecimal(txtListPrice.Text));
       cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblID.Text));
       conn.Open();
       int rowsAffected = cmd.ExecuteNonQuery();
       conn.Close();
    }
