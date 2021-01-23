         // Have Mono.Cecil load the assembly
         var assemblyDefinition = Mono.Cecil.AssemblyDefinition.ReadAssembly(assemblyFile.FullName);
         // Tell Mono.Cecil to actually change the name
         assemblyDefinition.Name.Name = newAssemblyNameNoExtension;
         assemblyDefinition.MainModule.Name = newAssemblyNameNoExtension;
         // We also need to rename any references to project assemblies (first pass assemblies)
         foreach (var reference in assemblyDefinition.MainModule.AssemblyReferences)
         {
            if (Utilities.IsProjectAssembly(reference.Name))
            {
               reference.Name = Utilities.GetModAssemblyName(reference.Name, this._modName);
            }
         }
         // Build the new assembly
         byte[] bytes;
         using (var ms = new MemoryStream())
         {
            assemblyDefinition.Write(ms, new Mono.Cecil.WriterParameters() { WriteSymbols = true });
            bytes = ms.ToArray();
         }
