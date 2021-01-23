    public class User
    {
        public string UName { get; set; }
        public string Auth { get; set; }
        public Boolean PUser { get; set; }
    }
    class DeveloperPreview
    {
        List<User> UserList = new List<User>();
        public void PopulateUsers()
        {
            UserList.Add(new User() { UName="Daryl",Auth="12345",PUser=true});
            UserList.Add(new User() { UName = "Test", Auth = "239", PUser = false });
            UserList.Add(new User() { UName="Developer",Auth="2",PUser=true});
        }
        public string Authenticateuser(string Username, string Auth)
        {
            var user = UserList.Where(t => t.UName == Username).FirstOrDefault();
            return user.UName;
        }
    }
