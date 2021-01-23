    public class ApiUserEntity // : BaseEntity
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Salt { get; set; }
    
            public ApiUserRole Role { get; set; }
    
            public ApiPermission Permission { get; set; }
    }
    
    public enum ApiUserRole
    {
            Admin,
            Guest
    }
    
    public enum ApiPermission
    {
            Write,
            Read,
            WriteRead
    }
