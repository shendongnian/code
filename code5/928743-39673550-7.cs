    private static string Load(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
    
        using (Stream stream = assembly.GetManifestResourceStream(name))
        using (StreamReader reader = new StreamReader(stream))
        {
            string result = reader.ReadToEnd();
            return result;
        }
    }
