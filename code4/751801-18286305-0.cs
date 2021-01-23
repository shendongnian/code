    public static Type GenerateLegacyStructureObject(string libraryName, string className, List<DynamicLibraryProperties> properties)
    {
        //your code
        Type t = legacyBuilder.CreateType(); 
        asmBuilder.Save(library);
        return t;
    }
