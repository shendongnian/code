    DataSet ds = new DataSet();
    using(var con = new SqlConnection("ConnectionString"))
    using(var da = new SqlDataAdapter("SELECT * FROM dbo.TableName ORDERBY ColumnName", con))
    {
        da.Fill(ds);
    }
