    var sql = "select BillNumber from BillData";
    using (SqlConnection cn = new SqlConnection(cString))
    using (SqlCommand cmd = new SqlCommand(sql, cn))
    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
        rdr.Read();
        MessageBox.Show(rdr.GetString(0));
    }
