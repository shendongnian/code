    public void ChangePanel<T>(T action)
    {
        Type typeOfObject = someObject.GetType();
        Type typeOfAction = typeof(T);
        FieldInfo field = typeOfObject.GetField(typeOfAction.Name);
        field.SetValue(someObject, action);
    }
