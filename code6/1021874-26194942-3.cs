    Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "YourNamespaceHere");
    for (int i = 0; i < typelist.Length; i++)
    {
        if (typelist[i].IsSubclassOf(typeof(Form))) {
               Console.WriteLine(typelist[i].Name); // Only forms will be written here
        }
    }
