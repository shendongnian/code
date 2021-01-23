    public class MyUserRepository
    {
        public string Name { get; set; }
        public Dictionary<string, string> Users { get; set; }
        public MyUserRepository(string name, Dictionary<string, string> users = null)
        {
            Name = name;
            Users = users ?? new Dictionary<string, string>();
        }
    }
