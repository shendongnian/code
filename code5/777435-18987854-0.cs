    businessObject = //your collection;
    //there might be two Add methods. Make sure you get the one which has one parameter.
    MethodInfo addMethod = businessObject.GetType().GetMethod("Add");
    foreach(object obj in businessObject as IEnumerable)
    {
        addMethod.Invoke(businessObject, new object[] { obj });
    }
