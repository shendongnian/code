    foreach(object obj in list)
    {
        if(obj.GetType().IsGenericType)
        {
            if(obj.GetType().GetGenericTypeDefinition() == typeof(MyFirstType<,>))
            {
              // do something
            }
            else if(obj.GetGenericTypeDefinition() == typeof(MySecondType<>))
            {
            }
        }
    }
