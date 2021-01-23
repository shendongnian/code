    public class UserRoleVM
    {
      public int ID { get; set; } // user ID for post back
      public int Name { get; set; } // user name for display in the view
      [Display(Name="Select new role")]
      public int SelectedRole { get; set; }
      public SelectList RoleList { get; set; }
    }
