    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }
    public enum UserType
    {
        Administrator = 1,
        Operator = 2,
        Consultor = 3
    }
