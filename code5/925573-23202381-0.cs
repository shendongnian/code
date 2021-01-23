    public void deleteRows(string table, string field, List<SqlParameter> inParameters)
    {
        StringBuilder sb new StringBuilder();
        sb.AppendFormat("SELECT COUNT(*) FROM {0} WHERE {1} IN (", table, field));
        using(SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = connection;
            // Loop over the parameter list, adding the parameter name to the 
            // IN clause and the parameter to the SqlCommand collection
            foreach(SqlParameter p in inParameters)
            {
                sb.Append(p.Name + ",");
                cmd.Parameters.Add(p);
            }
            // Trim out the last comma
            sb.Length--;
            // Close the IN clause
            sn.Append(")";
            cmd.CommandText = sb.ToString();
            fieldCount = (int)command.ExecuteScalar();
        }
    }
