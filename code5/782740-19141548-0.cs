    var codes = objDataset1.Tables[0].AsEnumerable()
                           .Select(r => r.Field<string>("code"));
    if (!code.Any())
        return;
    var sql = "INSERT INTO Table (Code, v1, v2, v3) VALUES (@code, @v1, @v2, @v3)";
    sc.Open();
    
    foreach(var code in codes)
    {        
        cmd = new SqlCommand(sql, sc);
        cmd.Parameters.AddWithValue("@code", code);
        cmd.Parameters.AddWithValue("@v1", ckv1.IsChecked);
        cmd.Parameters.AddWithValue("@v2", ckv2.IsChecked);
        cmd.Parameters.AddWithValue("@v3", txtv3.Text);
        cmd.ExecuteNonQuery();
    }
