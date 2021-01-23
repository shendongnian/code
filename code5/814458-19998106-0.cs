    public bool RecordExists(string a)
    {
        using(var con = new OracleConnection(constr))
        using(var cmd = con.CreateCommand())
        {
            cmd.CommandText = "select 1 from table where a=:a";
            cmd.Parameters.AddWithValue("a", a);
            con.Open();
            return cmd.ExecuteScalar() != null; // returns null if no rows
        }
    }
