    public event PropertyChangedEventHandler PropertyChanged;
  
    protected void RaisePropertyChanged<T>(Expression<Func<T>> action)
    {
        var propertyName = GetPropertyName(action);
        RaisePropertyChanged(propertyName);
    }
    private static string GetPropertyName<T>(Expression<Func<T>> action)
    {
         var expression = (MemberExpression)action.Body;
         var propertyName = expression.Member.Name;
         return propertyName;
    }
