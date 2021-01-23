    using (SqlConnection connection = new SqlConnection(connString))
    using (SqlCommand cmd = new SqlCommand("UPDATE Inventory SET qty = @qty WHERE sku = @sku", connection))
    {
        connection.Open();
        var paramqty=  cmd.Parameters.Add("@qty", SqlDbType.Int);
        var parasku = cmd.Parameters.Add("@sku", SqlDbType.VarChar);
        foreach (DataRow row in amzInventoryDataSet.Tables[0].Rows)
        {
            parasku.Value = row["seller-sku"].ToString();
            paramqty.Value = int.Parse(row["quantity"].ToString());
            cmd.ExecuteNonQuery();
        }
    }
