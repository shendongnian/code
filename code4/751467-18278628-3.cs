    public void DisplayEntity<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
    {
      foreach (var propertyValue in properties)
      {
        var m = propertyValue.Compile();
        Console.Write(m(entity));
      }
    }
    //...
    DisplayEntity<Contact>(contact, c => c.Name, c => c.IsEnabled);
