    var instance = new Test();
    instance.Name = "Jane";
    Type t = instance.GetType();
    string Value = t.GetPropertyValueOrDefault(instance, "Name", "JOHN");
    Console.WriteLine(Value);   // Returns Jane
    Value = t.GetPropertyValueOrDefault(instance, "Id", "JOHN");
    Console.WriteLine(Value);   // Returns JOHN
