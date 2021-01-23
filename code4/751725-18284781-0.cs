    // These buffers will receive the content of the embedded resource files.
    byte[] affFileBytes = null;
    byte[] dictFileBytes = null;
    // We have to load the resource files from the assembly in which they were embedded.
    var myAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Equals("MyApp.MyAssemblyWithResources")).Single();
    // To do so we need to get a stream that allows us to read them.
    using (var affResourceStream = myAssembly.GetManifestResourceStream("MyApp.MyAssemblyWithResources.AffFile"))
    using (var dictResourceStream = myAssembly.GetManifestResourceStream("MyApp.MyAssemblyWithResources.DictFile"))
    {
        // Now we know their size and can allocate room for the buffer.
        affFileBytes = new byte[affResourceStream.Length];
        // And read them from the resource stream into the buffer.
        affResourceStream.Read(affFileBytes, 0, affFileBytes.Length);
        // Same thing for the dictionary file.
        dictFileBytes = new byte[dictResourceStream.Length];
        dictResourceStream.Read(dictFileBytes, 0, dictFileBytes.Length);
    }
    // Now the loaded buffers can be used for the NHunspell instance.
    using (var hunspell = new Hunspell(affFileBytes, dictFileBytes))
    {
        // Do stuff with spellin and gramma.
    }
