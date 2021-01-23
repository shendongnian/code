    public byte[] ExtractResource(Assembly assembly, string resourceName)
    {
        if (assembly == null)
        {
            return null;
        }
        using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resFilestream == null)
            {
                return null;
            }
            byte[] bytes = new byte[resFilestream.Length];
            resFilestream.Read(bytes, 0, bytes.Length);
            return bytes;
        }
    }
