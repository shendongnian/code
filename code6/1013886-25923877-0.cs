    public class RoleVM
    {
      public short RoleId { get; set; }
      public string RoleName { get; set; }
      public bool IsSelected { get; set; }
    }
    public class UserVM
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<RoleVM> Roles { get; set; }
    }
