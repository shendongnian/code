    var obj = new
    {
        A = new DateTime(1234, 5, 6, 7, 8, 9, DateTimeKind.Utc),
        B = (DateTime?)null
    };
    Parse(obj, "A");
    Parse(obj, "B");
    static void Parse(object obj, string property)
    {
        var blob = obj.GetType().GetProperty(property).GetGetMethod()
           .GetMethodBody().GetILAsByteArray();
        // hard-code that we know the token is at offset 2
        int token = BitConverter.ToInt32(blob, 2);
        var field = obj.GetType().Module.ResolveField(token,
            obj.GetType().GetGenericArguments(), null);
        Console.WriteLine(field.Name);
        Console.WriteLine(field.MetadataToken);
    }
