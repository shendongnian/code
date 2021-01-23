            // Give the assembly a unique name
            var assemblyName = "Gen" + Guid.NewGuid().ToString().Replace("-", "") + ".dll";
            // Build the syntax tree
            var syntaxTree = CSharpSyntaxTree.ParseText(source);
            // Compile the code
            var compilation = CSharpCompilation.Create(
                assemblyName,
                options: new CSharpCompilationOptions(outputKind: OutputKind.DynamicallyLinkedLibrary),
                syntaxTrees: new List<SyntaxTree> { syntaxTree },
                references: GetMetadataReferences());
            // Emit the image of this assembly 
            byte[] image = null;
            using (var ms = new MemoryStream())
            {
                var emitResult = compilation.Emit(ms);
                if (!emitResult.Success)
                {
                    throw new InvalidOperationException();
                }
                image = ms.ToArray();
            }
            Assembly assembly = null;
            // NETCORE
            using (var stream = new MemoryStream(image))
                assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(stream);
