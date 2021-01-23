    using (TransactedInstaller installer = new TransactedInstaller())
    {
        string path = string.Format("/assemblypath={0}",          System.Reflection.Assembly.GetExecutingAssembly().Location);
        string[] arguments = { path };
        InstallContext context = new InstallContext("", arguments);
        using (ProjectInstaller projectInstaller = new ProjectInstaller())
        {
            installer.Installers.Add(projectInstaller );
        }
        
        installer .Context = context ;
        installer .Install(new Hashtable());
    }
