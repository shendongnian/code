    var user   = new User {Address = new Address{ User = new User() }};
    var values = new Dictionary<string, object>()
    {
        {"Name", "Sample"},
        {"Date", DateTime.Today},
        {"Address.PostalCode", "12345"},
        {"Address.User.Name", "Sub Sample"}
    };
    user.Bind(values);
    public class User
    {
        public string   Name     { get; set; }
        public DateTime Date     { get; set; }
        public Address  Address  { get; set; }
    }
    public class Address
    {
        public string PostalCode { get; set; }
        public User   User       { get; set; }
    }
