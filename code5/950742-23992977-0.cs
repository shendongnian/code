    Type type = myvar.GetType();  
    string className = type.ToString(); 
    Type genericType = Type.GetType(className);
    Type observableCollectionType = typeof(ObservableCollection<>);
    Type constructedType = observableCollectionType.MakeGenericType(genericType);
    var constructedInstance = Activator.CreateInstance(constructedClass);
