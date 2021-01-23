    private void RunDll2(string path, string typename)
    {
       AppDomain newDomain = AppDomain.CreateDomain("newDomain");
       AssemblyName assemblyName = AssemblyName.GetAssemblyName(path);
       Command cmd = (Command)newDomain.CreateInstanceAndUnwrap(assemblyName.FullName,     typename);
      cmd.Execute();
      cmd = null;
      AppDomain.Unload(newDomain);
    }
