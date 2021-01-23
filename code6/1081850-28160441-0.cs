    foreach (var proj in sln.Projects)
    {
        var comp = proj.GetCompilationAsync().Result;
        foreach (var st in comp.SyntaxTrees)
        {
            SyntaxTree activeSyntaxTree = st;
            var root = st.GetRoot() as CompilationUnitSyntax;
            foreach (var ns in root.Members.OfType<NamespaceDeclarationSyntax>())
            {
                foreach (ClassDeclarationSyntax @class in ns.DescendantNodes(d => true).OfType<ClassDeclarationSyntax>())
                {
                    foreach (var method in @class.Members.OfType<MethodDeclarationSyntax>().Where(m => HasAttribute(m, TEST_METHOD)))
                    {
                        //do something with this test method
                    }
                }
            }
        }
    }
