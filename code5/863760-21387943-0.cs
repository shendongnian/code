    // Get The Method by reflection
        MethodInfo serializerInfo = typeof(Serializer).GetMethod("Serialise2D_Rec",
                            BindingFlags.Public | BindingFlags.Static); 
    
    //Make a Generic instance of the type you want
        serializerInfo = serializerInfo.MakeGenericMethod(lst.GetType());
    
        List<object[]> serialisedProp = serializerInfo.Invoke(null, new object[] {lst});
