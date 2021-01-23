    public static class DirectoryStrings
    {
      private const string AppFolderName = "MyAppName";
      public static string ToolsFolderName
      {
        get { return Path.Combine(KnownFolders.GetDefaultPath(KnownFolder.Downloads), AppFolderName, "Tools"); }
      }
      public static string XmlFolderName
      {
        get { return Path.Combine(ToolsFolderName, "XML"); }
      }
      public static string CfgFolderName
      {
        get { return Path.Combine(ToolsFolderName, "cfg"); }
      }
    }
