    public interface IShared
    {
      DateTime CreatedOn { get; set; }
    }
    public interface ISharedValidation
    {
      [Required]
      DateTime CreatedOn { get; set; }
    }
    
    public interface IMyEntity: IShared
    {
      // Entity Specifics
      string Username { get; set; }
    }
    public interface IMyEntityValidation: ISharedValidation
    {
      [Required]
      string Username { get; set; }
    }
