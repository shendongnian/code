    public int Update(T entity, params Expression<Func<T, object>>[] properties)
    {
      myDataContext.Entry(entity).State = EntityState.Unchanged;
      foreach (var property in properties)
      {
        var propertyName = ExpressionHelper.GetExpressionText(property);
        myDataContext.Entry(entity).Property(propertyName).IsModified = true;
      }
      return myDataContext.SaveChangesWithoutValidation();
    }
