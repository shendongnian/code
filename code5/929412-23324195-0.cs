    var instance = new B();
    Type t = instance.GetType();
    
    bool isA = false;
    while(t != typeof(object))
    {
        if(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(A<>))
        {
            isA = true;
            break;
        }
        else
        {
            t = t.BaseType;
        }
    }
