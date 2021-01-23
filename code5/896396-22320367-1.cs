    private void CreateSelect(SqlCommand cmd)
    {
        var criteria = TextBox1.Text.Trim().Split(null, StringSplitOptions.RemoveEmptyEntries); // null specifies to split on whitespace
        var selectStatement = new StringBuilder("select  * from tbl1 where id is not null ");
        var counter = 0;
        if(criteria.Length < 0)
        {
           selectStatement.Append(" and (");
           foreach(var str in criteria)
           {
               var paramName = "@p" + counter;
               cmd.Parameters.Add(new SqlParameter(paramName, str);
               selectStatement.Append("compname  like '%" + paramName + "%' or ProductCategory like '%" + paramName  + "%' or CountryName like '%" + paramName  + "%'")
            }
            selectStatement.Append(")");
        }
        cmd.CommandText = selectStatement.ToString();
    }
