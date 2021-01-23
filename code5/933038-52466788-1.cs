    // Code is probably adapted from some other answer, don't remember
    public static void CompileToAssemblyFile(
      this LambdaExpression expression,
      string outputFilePath = null,
      string assemblyAndModuleName = null,
      string typeName = "TheType",
      string methodName = "TheMethod",
      // Adjust this
      string ilSpyPath = @"C:\path\to\ILSpy.exe")
    {
      assemblyAndModuleName = assemblyAndModuleName ?? nameof(CompileToAssemblyFile);
      outputFilePath = outputFilePath ??
                       Path.Combine(
                         Path.GetTempPath(),
                         $"{assemblyAndModuleName}_{DateTime.Now:yyyy-MM-dd_HH_mm_ss}_{Guid.NewGuid()}.dll");
      var domain = AppDomain.CurrentDomain;
      var asmName = new AssemblyName {Name = assemblyAndModuleName};
      var asmBuilder = domain.DefineDynamicAssembly(
        asmName,
        AssemblyBuilderAccess.RunAndSave,
        Path.GetDirectoryName(outputFilePath));
      string outputFileName = Path.GetFileName(outputFilePath);
      var module = asmBuilder.DefineDynamicModule(
        assemblyAndModuleName,
        outputFileName,
        true);
      var typeBuilder = module.DefineType(typeName, TypeAttributes.Public);
      var methodBuilder = typeBuilder.DefineMethod(
        methodName,
        MethodAttributes.Public | MethodAttributes.Static,
        expression.ReturnType,
        expression.Parameters.Select(p => p.Type).ToArray());
      var pdbGenerator = DebugInfoGenerator.CreatePdbGenerator();
      expression.CompileToMethod(methodBuilder, pdbGenerator);
      typeBuilder.CreateType();
      asmBuilder.Save(outputFileName);
      Process.Start(ilSpyPath, outputFilePath);
    }
