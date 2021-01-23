    public void InjectTrace()
    {
        this.CurrentSolution = this.LoadedWorkSpace.CurrentSolution;
        this.NewSolution = this.CurrentSolution;
        //For Each Project...
        foreach (var projectId in LoadedWorkSpace.CurrentSolution.ProjectIds)
        {
            CurrentProject = NewSolution.GetProject(projectId);
            //..for each Document in the Project..
            foreach (var docId in CurrentProject.DocumentIds)
            {
                var dict = new Dictionary<CommonSyntaxNode, CommonSyntaxNode>();
                CurrentDocument = NewSolution.GetDocument(docId);
                var docRoot = CurrentDocument.GetSyntaxRoot();
                var classes = docRoot.DescendantNodes().OfType<ClassDeclarationSyntax>();
                //..for each Class in the Document..
                foreach (var @class in classes)
                {
                    var methods = @class.Members.OfType<MethodDeclarationSyntax>();
                    //..for each Member in the Class..
                    foreach (var currMethod in methods)
                    {
                        //..insert a Trace Statement
                        dict.Add(currMethod, InsertTrace(currMethod));
                    }
                }
                if (dict.Any())
                {
                    var newDocRoot = docRoot.ReplaceNodes(dict.Keys, (n1, n2) => dict[n1]);
                    var newDocument = CurrentDocument.UpdateSyntaxRoot(newDocRoot);
                    NewSolution = NewSolution.UpdateDocument(newDocument);
                }
            }
        }
    }
