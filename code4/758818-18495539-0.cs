    string name = nameSpace + "." +
       (internalFilePath== "" ? "" : internalFilePath + ".") + resourceName;
    Stream s = assembly.GetManifestResourceStream(name);
    if (s == null)
    {
        throw new ApplicationException(); // or whatever
    }
    using (s)
    {
        // other stuff here
    }
