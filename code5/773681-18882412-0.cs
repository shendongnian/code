    public static ArrayList LoadInfo<T>(string sql, Func<SqlDataReader, T> getItem) where T: new
    {
        var list = new ArrayList();
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            list.Add(getItem(dr));
        }
        return list;
    }
    public static User LoadUser(SqlDataReader dr)
    {
        User structure_A = new User();
        structure_A.username = dr.GetValue(0).ToString();
        structure_A.status   = dr.GetValue(1).ToString();
        return User;
    }
