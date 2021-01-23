    public Func<object, object> RecordMethod(string typeName, string methodName)
    {
        var type = Type.GetType(typeName);
        var method = type.GetMethod(methodName);
        return (object o) => method.Invoke(o, new object[0]);
    }
    var method = RecordMethod("MemberRequestDTO", "RecordsToRetrieve");
    // later that day ...
    MemberRequestDTO someObj = ...;
    var result = method.Invoke(someObj);
