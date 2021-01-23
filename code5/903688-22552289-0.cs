    public class User : IUser
    {
      public virtual Guid Id { get; set; }
      string IUser.Id{get{return this.Id.ToString();}}
      public virtual string UserName { get; set; }
    }
