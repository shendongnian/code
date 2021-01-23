    public DbDataAdapter CreateDataAdapter(DbConnection conn)
    {
       if (System.Runtime.Version >= 45)
       {
          return Hide45DependencyFromJit(connection);
       }
       else
       {
          //...snip the hack...
       }
    }
    
    private void Hide45DependencyFromJit(... connection)
    {
          return DbProviderFactories.GetFactor(connection).CreateDataAdapter();
    }
