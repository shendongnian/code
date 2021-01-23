    public static String FindFileDeep(String path, String fileName) {
      foreach(String file in Directory.EnumerateFiles(path))
        if (String.Equals(Path.GetFileName(file), fileName, StringComparison.OrdinalIgnoreCase))
          return file;
      foreach (var dir in Directory.EnumerateDirectories(path)) {
        String result = FindIndexHtml(dir);
        if (!String.IsNullOrEmpty(result))
          return result;
      }
      return null;
    }
    ...
    String indexHtml = FindFileDeep(@"C:\MyFiles", "index.html");
