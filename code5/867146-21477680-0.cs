    var assembly = Assembly.GetExecutingAssembly();
    using (var stream =
        assembly.GetManifestResourceStream("TheFolderIAdded.Filename.ext"))
    using (var reader = new StreamReader(stream)) {
      string fileContents = reader.ReadToEnd();
    }
