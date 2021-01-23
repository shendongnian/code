    var assm = Assembly.GetExecutingAssembly();
    using (var stream = assm.GetManifestResourceStream("WindowsFormsApplication.file.txt"))
    {
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ...
            }
        }
    }
