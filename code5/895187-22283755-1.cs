        var referenceAssemblies = new List<string> {
            "System.dll",
            "System.Data.dll",
            "System.Xml.dll",
            "System.Windows.Forms.dll" 
        };
        var homedir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var mshtml = Path.Combine(homedir, "Microsoft.mshtml.dll");
        referenceAssemblies.Add(mshtml);
        cp.ReferencedAssemblies.AddRange(referenceAssemblies.ToArray());
