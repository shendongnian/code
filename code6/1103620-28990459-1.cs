    private static T? GetProperty<T>(this GridViewColumn column, DependencyProperty dp) where T : struct
    {
      if (column == null)
      {
        throw new ArgumentNullException("column");
      }
      object value = column.ReadLocalValue(dp);
      if (value != null)
      {
        Type type = value.GetType();
        if (type == dp.PropertyType)
        {
          return (T)value;
        }
        else if (type == typeof(System.Windows.Data.BindingExpression))
        {
          System.Windows.Data.BindingExpression be = (System.Windows.Data.BindingExpression)value;
          if (be.ResolvedSource != null && be.ResolvedSourcePropertyName != null)
          {
            return (T)be.ResolvedSource.GetBoundValue(be.ResolvedSourcePropertyName);
          }
        }
      }
      return null;
    }
    private static object GetBoundValue(this object source, string property)
    {
      return source.GetType().GetProperty(property).GetValue(source);
    }
