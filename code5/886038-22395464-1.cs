    var assembly = AssemblyDefinition.ReadAssembly(assemblyPath);
    var type = assembly.MainModule.Types.Where(t => t.Name.Contains("WithAttribute")).Single();
    var attr = type.CustomAttributes.Where(ca => ca.AttributeType.FullName.Contains("MyAttribute")).Single();
    type.CustomAttributes.Remove(attr);
    var newAttr = new CustomAttribute(attr.Constructor)
    { 
        ConstructorArguments = 
        {
            new CustomAttributeArgument(
                 attr.ConstructorArguments[0].Type, 
                 attr.ConstructorArguments[0].Value + "-Appended"),
            new CustomAttributeArgument(
                 attr.ConstructorArguments[1].Type, 
                 attr.ConstructorArguments[1].Value)
         }
    };
			
    type.CustomAttributes.Add(newAttr);
    assembly.Write(path);
