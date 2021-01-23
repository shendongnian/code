    var inmutableArray =(new List<IDiagnosticAnalyzer>
            {
                new VariableEndedWithIdNamedCorrectlyDiagnosticAnalyzer()
            }).ToImmutableArray();
    var analyzerImageReference = new AnalyzerImageReference(inmutableArray);
    Solution newSolution = solution;
    
    //We iterate over the original solution
    foreach (Project project in solution.Projects)
    {                   
        //But we save our work in the newSolution
        newSolution = newSolution.AddAnalyzerReference(project.Id, analyzerImageReference);
    }
    //Now newSolution should contain all your changes.
    //Maybe you want to save this reference?
    solution = newSolution;
