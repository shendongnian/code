    AppDomain.CurrentDomain // Necessary to get all available Assemblies
        .GetAssemblies()    // Gets all the assemblies currently loaded in memory that this code can work with
        .AsParallel()       // Highly recommended to make the attribute-checking steps run asynchronously
                            // Also gives you a handy .ForAll Method at the end
        // TODO: .Where Assembly contains Attribute
        .SelectMany(assembly => assembly.GetTypes())
        // TODO: .Where Type contains Attribute
        .SelectMany(type => type.GetProperties)
        // TODO: Make sure Property has the right data...
        .Select(CompileFromProperty)
