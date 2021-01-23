    public class RoleVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
    public class UserVM
    {
      public UserVM()
      {
        Roles = new List<RoleVM>();
      }
      public int ID { get; set; }
      public string Name { get; set; }
      public List<RoleVM> Roles { get; set; }
    }
