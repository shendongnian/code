    // Container for results
    List<string> classes = new List<string> ();
    List<string> interfaces = new List<string> ();
    // Get selected projects from solution explorer
    Array projects = (Array)_applicationObject.ActiveSolutionProjects;
    // Get all ProjectItems inside of the selected Projects
    var projectItems = projects
        .OfType<Project> ()
        .Where ( p => p.ProjectItems != null )
        .SelectMany ( p => p.ProjectItems.OfType<ProjectItem> ().Where ( pi => pi.FileCodeModel != null ) );
    // Iterate over all of these ProjectItems 
    foreach ( ProjectItem projectItem in projectItems )
    {
        // Get all of the CodeElements (Interfaces and Classes) inside of the current ProjectItem (recursively)
        var elements = projectItem.FileCodeModel.CodeElements
            .OfType<CodeElement> ()
            .SelectMany ( ce => this.GetCodeElements ( ce ) );
        // Do something with the CodeElements that were found
        classes.AddRange ( elements.Where ( el => el.Kind == vsCMElement.vsCMElementClass ).Select ( el => el.Name ) );
        interfaces.AddRange ( elements.Where ( el => el.Kind == vsCMElement.vsCMElementInterface).Select ( el => el.Name ) );
    }
    // Possible implementation of GetCodeElements:
    private IEnumerable<CodeElement> GetCodeElements ( CodeElement root )
    {
        List<CodeElement> result = new List<CodeElement> ();
        if ( root == null )
            return result;
        // If the current CodeElement is an Interface or a class, add it to the results
        if ( root.Kind == vsCMElement.vsCMElementClass || root.Kind == vsCMElement.vsCMElementInterface )
        {
            result.Add ( root );
        }
        // Check children recursively
        if ( root.Children != null && root.Children.Count > 0 )
        {
            foreach ( var item in root.Children.OfType<CodeElement> () )
            {
                result.AddRange ( this.GetCodeElements ( item ) );
            }
        }
    }
