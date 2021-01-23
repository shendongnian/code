    var myClass = new MyClass();
    
    foreach (var fieldInfo in myClass.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    {
        var fieldType = fieldInfo.FieldType;
    
        if (!fieldType.IsGenericType ||
            fieldType.GetGenericTypeDefinition() != typeof (UserProp<>))
        {
            Console.WriteLine("Ignoring {0} {1}", fieldType.Name, fieldInfo.Name);
            continue;
        }
    
        var fieldValue1 = fieldInfo.GetValue(myClass);
        var fieldInfo2 = fieldValue1.GetType().GetField("IsSet");
        var fieldValue2 = fieldInfo2.GetValue(fieldValue1);
    
        Console.WriteLine("{0}.IsSet has a value of {1}", fieldInfo.Name, fieldValue2);
        // You can check fieldValue2 and if true you now have "[a field] of
        // MyClass of type UserProp (regardless of generic type) where IsSet
        // is true". Loop until you get them all!
    }
