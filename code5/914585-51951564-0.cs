    var compilation = CSharpCompilation.Create(
        "calc.dll",
        options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
        syntaxTrees: new[] {tree},
        references: new[] {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ExpandoObject).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("Microsoft.CSharp")).Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("netstandard")).Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("mscorlib")).Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Runtime")).Location),            
        }
    );
    
