    public static IWriter ChooseWriter(string writer)
    {
        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == writer);
        return (IWriter )Activator.CreateInstance(currentType);
    }
