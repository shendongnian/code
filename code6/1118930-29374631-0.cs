    MethodInfo method = (from x in typeof(JsonMapper).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(x => x.Name == "ToObject" && x.IsGenericMethodDefinition)
                        let pars = x.GetParameters()
                        where pars.Length == 1 && pars[0].ParameterType == typeof(string)
                        select x).Single();
    // Your generic type
    Type type = Type.GetType("System.String");
    MethodInfo method2 = method.MakeGenericMethod(type);
    // Your input
    string jsonString = "Hello";
    object result = method2.Invoke(null, new object[] { jsonString });
