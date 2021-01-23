    public IQueryable<T> GetTable<T>() where T : class
    {
     var table = m_entities.CreateObjectSet<T>();
     return table;
    }
    
    public string MyData<T>() where T: class { 
    
      var table = GetTable<T>(); //order here
    
     }
