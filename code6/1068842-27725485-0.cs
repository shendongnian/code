    public T getValue<T>(string query, List<SqlParameter> param) {
        // your existing code
        object value = cmd.ExecuteScalar();
        // This line will change the to the right type. You still need to handle null
        // and various Nullable type if you use these
        return Convert.ChangeType(value, typeof(T));
    }
    // to use
    int cnt = getValue<int>(query, params);
