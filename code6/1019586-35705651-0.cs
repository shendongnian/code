    string[] dlls = { @"path1\a.dll", @"path2\b.dll" };
    foreach (string dll in dlls)
    {
        using (FileStream dllFileStream = new FileStream(dll, FileMode.Open, FileAccess.Read))
        {
             BinaryReader asmReader = new BinaryReader(dllFileStream);
             byte[] asmBytes = asmReader.ReadBytes((int)dllFileStream.Length);
             AppDomain.CurrentDomain.Load(asmBytes);
        }
    }
    // attach an event handler to manage the assembly loading
    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
