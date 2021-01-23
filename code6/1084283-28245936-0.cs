    var method= typeof(Console)
                     .GetMethod("WriteLine",
                                BindingFlags.Public | BindingFlags.Static,
                                null,
                                new [] { typeof(string) },
                                null);
    method.Invoke(null, new object[] { "Hello" });
