    public void DisplayEntity<TEntity, TProperty>(TEntity entity, params Expression<Func<TEntity, TProperty>>[] properties)
    {
      foreach (var propertyValue in properties)
      {
        var m = propertyValue.Compile();
        Console.Write(m(entity));
      }
    }
