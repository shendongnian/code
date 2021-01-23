    public IEnumerable<CodeClass> GetSubClasses(string baseClass, Project project)
    {
        var classes = VisualStudioHelper.CodeModel.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false);
        var subClasses = new List<CodeClass>();
        foreach (CodeClass @class in classes)
        {
            foreach (CodeClass @base in GetInheritance(@class))
            {
                if (@base.FullName == baseClass)
                    subClasses.Add(@class);
            }
        }
        return subClasses;
    }
    public IEnumerable<CodeClass> GetInheritance(CodeClass @class)
    {
        return GetInheritance(@class, new List<CodeClass>());
    }
    public IEnumerable<CodeClass> GetInheritance(CodeClass @class, List<CodeClass> collection)
    {
        foreach (CodeClass @base in @class.Bases)
        {
            collection.Add(@base);
            GetInheritance(@base, collection);
        }
        return collection;
    }
