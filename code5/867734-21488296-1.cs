    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand.CommandText = "select * from tblclientinfo where clientId = @id";
    da.SelectCommand.Parameters.AddWithValue("@id", txtid);
    da.SelectCommand.Connection = conn;
    DataSet ds = new DataSet();
    da.Fill(ds);
    foreach (DataRow row in ds.Tables[0].Rows)
    {
       txtid.Text = row["clientId"].ToString();
       txtname.Text = row["name"].ToString();
        ...
    }
