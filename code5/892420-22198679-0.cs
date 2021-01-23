    public partial class UserManager_User
    {
      public string GroupName { get { return this.Group.Name; } }
      // See how the getter traverses across the "Group" relationship
      // to get the name?
    }
