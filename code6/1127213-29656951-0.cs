        class User
        {
            public string FName, LName;
            public User(string fname, string lname) { FName = fname; LName = lname; }
        }
        static void Main(string[] args)
        {
            var lst = new[] { new User("John", "Smith"), new User("Will", "Smith"), new User("John", "Smith") };
            var usernames = lst.Select((u, i) => u.FName + u.LName.Substring(0, lst.Take(i - 1).Count(iu => iu.FName == u.FName && iu.LName == u.LName) + 1));
            Console.WriteLine(string.Join(" ", usernames));
        }
