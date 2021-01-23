    foreach (var manifestResourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
    {
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceName))
        {
            if (stream != null)
            {
                using (var rr = new ResourceReader(stream))
                {
                    foreach (DictionaryEntry resource in rr)
                    {
                        var name = resource.Key.ToString();
                              
                        string resourceType;
                        byte[] dataBytes;
                        rr.GetResourceData(name, out resourceType, out dataBytes);
                    }
                }
            }
        }
    }
