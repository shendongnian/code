    string[] fileNames = ...; // get all the filenames
    foreach (string fileName in fileNames) {
        var assembly = System.Reflection.Assembly.ReflectionOnlyLoadFrom(fileName);
        var referencedAssemblies = assembly.GetReferencedAssemblies();
        foreach (var assemblyName in referencedAssemblies) {
            // do your comparison
        }
    }
