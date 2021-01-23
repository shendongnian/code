    public static List<Assembly> GetAssemblies()
    {
        List<Assembly> assemblies = new List<Assembly>();
        foreach (var assemblyPart in Deployment.Current.Parts)
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri(assemblyPart.Source, UriKind.Relative));
            Assembly a = new AssemblyPart().Load(sri.Stream);
            if (a != null)
                assemblies.Add(a);
        }
        return assemblies;   
    }
