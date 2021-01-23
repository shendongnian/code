    {
        // Execute in startup
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
    }
    private Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
    {
        string RESOURCES = ".resources";
        try
        {
            /* Extract assembly name */
            string[] sections =  args.Name.Split(new char[] { ',' });
            if (sections.Length == 0) return null;
            string assemblyName = sections[0];
            /* If assembly name contains ".resource", you don't need to load it*/
            if (assemblyName.Length >= RESOURCES.Length &&
                    assemblyName.LastIndexOf(RESOURCES) == assemblyName.Length - RESOURCES.Length)
            {
                return null;
            }
            /* Load assembly to current domain (also you can use simple way to load) */
            string assemblyFullPath = "..//..//Libs//" + assemblyName;
            FileStream io = new FileStream(assemblyNameWithExtension, FileMode.Open, FileAccess.Read);
            if (io == null) return null;
            BinaryReader binaryReader = new BinaryReader(io);
            Assembly assembly = Assembly.Load(binaryReader.ReadBytes((int)io.Length));
            return assembly;
       }
       catch(Exception ex)
       {}
    }
