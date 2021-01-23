    string fullname = string.Format("{0}.{1}", this.GetType().Namespace, classname);
    Type type = Type.GetType(fullname,true);
    Baseclass class = (BaseClass)Activator.CreateInstance(type,<parameter1>,...);
    MethodInfo methodInfo = type.GetMethod("<method>");
    methodInfo.Invoke(class, null);
