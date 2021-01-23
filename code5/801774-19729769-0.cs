    public class Person
    {
        public string Name { get; set; }
    }
    
    public class User : Person
    {
        public string Title { get; set; }
        public string Email { get; set; }
    }
    
    public dynamic Get()
    {
        var user = new User { Title = "Developer", Email = "foo@bar.baz", Name = "MyName" };
    
        return new { user.Name, user.Email };
    }
