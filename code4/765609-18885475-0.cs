    private static void LoadDependencyAssemblies() 
    {
        UnityConfigurationSection section = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
        if (section == null)
        {
            throw new ConfigurationErrorsException("Unable to locate Unity configuration section.");
        }
        foreach (string assemblyName in section.Assemblies.Select(element => element.Name))
        {
            try
            {
                Assembly.Load(assemblyName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Unable to load required assembly specified in Unity configuration section.  Assembly: " + assembly, ex);
            }
        }
    }
