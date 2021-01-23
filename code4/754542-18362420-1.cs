    var itemsToConvert = new[] { "4", "5.98", "false", DateTime.Now.ToString() };
    var @int = itemsToConvert[0].Convert<int>();
    var @double = itemsToConvert[1].Convert<double>();
    var @bool = itemsToConvert[2].Convert<bool>();
    var @dateTime = itemsToConvert[3].Convert<DateTime>();
    Console.WriteLine(@"int: {0}, Type: {1}", @int, @int.GetType());
    Console.WriteLine(@"double: {0}, Type: {1}", @double, @double.GetType());
    Console.WriteLine(@"bool: {0}, Type: {1}", @bool, @bool.GetType());
    Console.WriteLine(@"DateTime: {0}, Type: {1}", @dateTime, @dateTime.GetType());
