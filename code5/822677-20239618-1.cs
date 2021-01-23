    DataSet ds = new DataSet();
    using(var con = new SqlConnection(connectionString))
    using(var da = new SqlDataAdapter("SELECT * FROM dbo.TableName ORDER BY ColumnName", con))
    {
        da.Fill(ds);
    }
