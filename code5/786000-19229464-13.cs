    public void SetPropertyChanged<T>(Expression<Func<T, Object>> onProperty) 
    {
        if (PropertyChanged != null && onProperty.Body is MemberExpression) 
        {
            String propertyNameAsString = ((MemberExpression)onProperty.Body).Member.Name;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyNameAsString));
        }
    }
