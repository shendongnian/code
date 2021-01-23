    public interface ICurrentContext
    {
         User CurrentUser { get; set; } // User is my User class which holds some user properties
         int? CurrentUserId { get; }
    }
