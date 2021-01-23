    public void MyFunction(string ns)
    {
        var typesReader = from asm in AppDomain.CurrentDomain.GetAssemblies()
                          from type in asm.GetExportedTypes()
                          where type.Namespace == ns
                          select type;
        var typeMap = typesReader.ToDictionary(t => t.Name);
        var type1 = typeMap["Type1"];
        ...
    }
    void Main()
    {
        MyFunction("X");
        MyFunction("Y");
    }
