    public int RunAssembly(string filePath, Object[] parameters)
    {
        AppDomainSetup adSetup = new AppDomainSetup();
        adSetup.ApplicationBase = Path.GetDirectoryName(filePath);
        PermissionSet permSet = new PermissionSet(PermissionState.None);
        permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
        StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();
        newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);
        ObjectHandle handle = Activator.CreateInstanceFrom(
            _newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
            typeof(Sandboxer).FullName
            );
        newDomainInstance = (Sandboxer)handle.Unwrap();
        
        string assemblyName = Path.GetFileNameWithoutExtension(filePath);
        return newDomainInstance.ExecuteAssembly(assemblyName, parameters);
    }
    public int ExecuteAssembly(string assemblyName, Object[] parameters)
    {
        MethodInfo target = Assembly.Load(assemblyName).EntryPoint;
        (new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)).Assert();
        return target.Invoke(null, parameters);
    }
