    public C Read<C, T>(Func<SqlConnection, SqlDataReader> func, Action<C, T> a)
        where C : ICollection, new()
        where T : EntityBase, new()
    {
        C objects = new C();
        using (SqlConnection connection = GetConnection())
        {
            using (SqlDataReader reader = func(connection))
            {
                while (reader.Read())
                {
                    T obj = new T();
                    obj.PopulateFromReader(reader);
                    a(objects, obj);
                }
            }
        }
        return objects;
    }
