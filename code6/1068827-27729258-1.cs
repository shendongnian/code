    public const string AssemblySystem_Windows_Forms = "System.Windows.Forms, Version=" + FxVersion + ", Culture=neutral, PublicKeyToken=b77a5c561934e089";
    // ...
    static Assembly swf;
    static Type resxr;
    static Type resxw;
    /*
     * We load the ResX format stuff on demand, since the classes are in 
     * System.Windows.Forms (!!!) and we can't depend on that assembly in mono, yet.
     */
    static void LoadResX () {
        if (swf != null)
            return;
        try {
            swf = Assembly.Load(Consts.AssemblySystem_Windows_Forms);
            resxr = swf.GetType("System.Resources.ResXResourceReader");
            resxw = swf.GetType("System.Resources.ResXResourceWriter");
        } catch (Exception e) {
            throw new Exception ("Cannot load support for ResX format: " + e.Message);
        }
    }
    // ...
    static IResourceReader GetReader (Stream stream, string name, bool useSourcePath) {
        string format = Path.GetExtension (name);
        switch (format.ToLower (System.Globalization.CultureInfo.InvariantCulture)) {
        // ...
        case ".resx":
            LoadResX ();
            IResourceReader reader = (IResourceReader) Activator.CreateInstance (
                resxr, new object[] {stream});
            if (useSourcePath) { // only possible on 2.0 profile, or higher
                PropertyInfo p = reader.GetType ().GetProperty ("BasePath",
                    BindingFlags.Public | BindingFlags.Instance);
                if (p != null && p.CanWrite) {
                    p.SetValue (reader, Path.GetDirectoryName (name), null);
                }
            }
            return reader;
        // ...
        }
    }
