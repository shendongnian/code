    public class FileVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
    }
    public class CategoryVM
    {
      public string ID { get; set; }
      public string Name { get; set; }
      public IEnumerable<FileVM> Files { get; set; }
    }
