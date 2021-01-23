     using System.ComponentModel;
     namespace RustyLazyLoadTester.Mobile.Services.Models
     {
    public class User
    {
        public User() { }
        public User(long id, string firstName, string lastName, UserStatus status)
            : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; }
    }
    public enum UserStatus
    {
        [Description("All")]
        All = 0,
        [Description("Inactive")]
        Inactive = 1,
        [Description("Active")]
        Active = 2,
        [Description("Deactivated")]
        Deactivated = 3
    }
    }
