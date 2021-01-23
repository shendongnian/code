    var assemblies = new Dictionary<string, Assembly>();
    var executingAssembly = Assembly.GetExecutingAssembly();
    var resources = executingAssembly.GetManifestResourceNames().Where(n => n.EndsWith(".dll"));
    foreach (string resource in resources)
    {
        using (var stream = executingAssembly.GetManifestResourceStream(resource))
        {
            if (stream == null)
                continue;
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            try
            {
                //After Assembly.Load is called, you can find the File Version
                assemblies.Add(resource, Assembly.Load(bytes));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("Failed to load: {0}, Exception: {1}", resource, ex.Message));
            }
        }
    }
