    private void AddItemsToCollectionAndInvokePropertyChanged<T,U>(Expression<Func<U>> propertyNameExpression, IList<T> addItems)
    {
        var p = (PropertyInfo)((MemberExpression)propertyNameExpression.Body).Member;
        var c = (ExtendedObservableCollection<T>)p.GetValue(this, null);
        c.AddItems(addItems);
        OnPropertyChanged(propertyNameExpression);
    }
