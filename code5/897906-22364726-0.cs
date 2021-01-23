    //DetermineSerializedType here would be your own method to determine the type you have
    Type deserializedType = DetermineSerializedType(serializedData);
    Type genericType = typeof(List<>).MakeGenericType(deserializedType);
    ConstructorInfo ctor = genericType.GetConstructor(new Type[] { });
    object inst = ctor.Invoke(new object[] { });
    IList list = inst as IList;
