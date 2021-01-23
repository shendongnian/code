    Type type = Type.GetType(te1.GetValue("class1"));
    MethodInfo method = type.GetMethod("fnc1");
    object obj1 = Activator.CreateInstance(type);
    
    method.Invoke(obj1, new object[] {});
    class2 cls2 = new class2();
    
    cls2.GetType().GetMethod("fnc2").Invoke(cls2, new[] {obj1});
