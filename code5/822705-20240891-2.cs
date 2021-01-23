    private static IEnumerable<Type> GetMatchingTypes(string opcode)
    {
        var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
        foreach (var file in files)
        {
            Type[] types;
            try
            {
                types = Assembly.LoadFrom(file).GetTypes();
            }
            catch
            {
                continue;  // Can't load as .NET assembly, so ignore
            }
            var interestingTypes =
                types.Where(t => t.IsClass &&
                                 t.GetInterfaces().Contains(typeof (IInstruction)) &&
                                 t.Name.Equals(opcode, StringComparison.InvariantCultureIgnoreCase));
            foreach (var type in interestingTypes)
                yield return type;
        }
    }
