    public MethodDefinition FindMethodDefinition(CodeFunctionWithIndex pCodeFunction, bool pHasAnExplicitlyDefinedCtor)
    {
        //Get the assembly that should contain the function we seek
        //Note : this is done by comparing pCodeFunction's assembly name to every assembly's name (without the extension)
        ModuleDefinition assemblyContainingMethod = assemblies
            .Where(assem =>
                assem.Name.Split(new char[] { '.' }).FirstOrDefault()
                .Equals(pCodeFunction.CodeFunction.ProjectItem.ContainingProject.Properties.Item("AssemblyName").Value, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault();
        //Get the class that should contain the function we seek
        //Note : pCodeFunction.Parent.Name is the class name of our pCodeFunction
        TypeDefinition classContainingMethod =
            assemblyContainingMethod.Types
                .Where(cl => cl.Name.Equals(((CodeClass)pCodeFunction.CodeFunction.Parent).Name))
                .FirstOrDefault();
        //below is what you want to see
        bool isCtorAtIndexZero = DTE.ActiveDocument.ProjectItem.Name.EndsWith(".vb");
        int functionIndex = 0;
        for (int i = 0; i < classContainingMethod.Methods.Count; i++)
        {
            if (!pHasAnExplicitlyDefinedCtor && isCtorAtIndexZero && i == 0)
                continue;
            if (functionIndex == pCodeFunction.Index)
                return classContainingMethod.Methods[i];
            functionIndex++;
        }
        return null;
    }
