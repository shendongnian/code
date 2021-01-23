    private void CreateSelect(SqlCommand cmd)
    {
        string [] criteria = TextBox1.Text.Trim().Split(null, StringSplitOptions.RemoveEmptyEntries); // null specifies to split on whitespace
        var params = new List<SqlParameter>[];
        var selectStatement = new StringBuilder("select  * from tbl1 where id is  not null");
        var counter = 0;
        foreach(var str in criteria)
        {
           var paramName = "@p" + counter;
           cmd.Parameters.Add(new SqlParameter(paramName, str);
           selectStatement.Append(" and compname  like '%" + paramName + "%' or ProductCategory like '%" + paramName  + "%' or CountryName like '%" + paramName  + "%'")
        }
    
        cmd.CommandText = selectStatement.ToString();
    }
