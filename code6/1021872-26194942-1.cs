    Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "YourNamespaceHere");
    for (int i = 0; i < typelist.Length; i++)
    {
        Console.WriteLine(typelist[i].Name);
    }
