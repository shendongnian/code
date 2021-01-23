    foreach (GridViewRow row in GridView1.Rows)
    {
        string sql = GenerateSql(row);
        if (!string.IsNullOrEmpty(sql))
            ExecuteNonQuery(sql);
    }
    private void ExecuteNonQuery(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd_server = new SqlCommand(query, conn))
        {
            conn.Open();
            cmd_server.ExecuteNonQuery();
        }
    }
    private string GenerateSql(GridViewRow row)
    {
        var values = row.Cells.Cast<TableCell>().Select(x => x.Text).ToArray();
        if (values.Any(string.IsNullOrEmpty))
        {
            return string.Empty;
        }
        var sql = string.Format("INSERT INTO  [Ref].[{0}] VALUES ({1})", _lstview_item, string.Join(",", values));
        return sql;    
    }
