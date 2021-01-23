    Type genericType = typeof(Deserializer<>);
    Type[] typeArgs = { Type.GetType("Person") };
    Type deserializerType = genericType.MakeGenericType(typeArgs);
    
    object deserializer = Activator.CreateInstance(deserializerType);
    
    MethodInfo fromFileMethod = deserializerType.GetMethod("FromFile");
    fromFileMethod.Invoke(deserializer, new[] { file });
