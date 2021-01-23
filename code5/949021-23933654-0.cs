    delegate T MyDelegate<T>(string tableName, string fieldName, params IDbDataParameter[] parameters);
        
    private T GetField<T>(string tableName, string fieldName, params IDbDataParameter[] parameters)
    {
      return default(T);
    }
        
    void Main()
    {
      MyDelegate<int> del = this.GetField<int>;
    }
