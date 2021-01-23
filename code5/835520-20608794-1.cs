    public class User
    {
        // Properties as before
        ...
        [Ignore] // This isn't a database field
        public bool SendWelcomeEmail { get; set; }
    }
