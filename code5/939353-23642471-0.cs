    public static class Program
    {
        public static void Main(string[] args)
        {
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var defaultReferences = new[] { "mscorlib.dll", "System.dll", "System.Core.dll" };
            var script = @"using System;
            public static class Program
            {
                public static void Main(string[] args)
                {
                    Console.WriteLine(""Hello {0}"", args[0]);
                }
            }";
            // Parse the script to a SyntaxTree
            var syntaxTree = CSharpSyntaxTree.ParseText(script);
            // Compile the SyntaxTree to a CSharpCompilation
            var compilation = CSharpCompilation.Create("Script",
                new[] { syntaxTree },
                defaultReferences.Select(x => new MetadataFileReference(Path.Combine(assemblyPath, x))),
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
            using (var outputStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
                // Emit assembly to streams.
                var result = compilation.Emit(outputStream, pdbStream: pdbStream);
                if (!result.Success)
                {
                    return;
                }
                // Load the emitted assembly to find and invoke the entry point.
                var assembly = Assembly.Load(outputStream.ToArray(), pdbStream.ToArray());
                assembly.EntryPoint.Invoke(null, new object[] { new[] { "Tomas" } });
            }
        }
    }
