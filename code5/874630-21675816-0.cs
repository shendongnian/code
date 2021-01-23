    var returnedType = dg.ItemsSource.AsQueryable().ElementType;
    Type generic = typeof(ObservableCollection<>);    
    Type specific = generic.MakeGenericType(typeof(returnedType));    
    ConstructorInfo ci = specific.GetConstructor(Type.EmptyTypes);    
    object o = ci.Invoke(new object[] { });
    
