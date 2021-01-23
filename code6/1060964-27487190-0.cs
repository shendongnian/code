    Type realtype = value.GetType();
    PropertyInfo indexProperty = realtype.GetProperty("Item");
    if (indexProperty.GetGetMethod() != null)
    {
         // analyze the MethodInfo you get using GetGetMethod
    }
