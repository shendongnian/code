    var obj = FormatterServices.GetUninitializedObject(typeof(MyClass));
    var ctor = obj.GetType().GetConstructor(
        BindingFlags.Instance | BindingFlags.Public| BindingFlags.NonPublic,
        null,
        new[] { typeof(SerializationInfo), typeof(StreamingContext) },
        null);
    ctor.Invoke(obj, new object[2]);
