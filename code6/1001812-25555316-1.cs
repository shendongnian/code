      public class MyFolderModel
      {
          public string Name { get; set; }
          public IEnumerable<MyFileModel> Files { get; set; }
      }
      public class MyFileModel
      {
          public string Name { get; set; }
      }
