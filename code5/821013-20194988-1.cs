    using System.Collections.Generic;
    
    namespace WpfTestBench
    {
        public partial class TreeSample
        {
            public TreeSample()
            {
                InitializeComponent();
    
                DataContext = new Context();
            }
        }
    
        public class Context
        {
            public Context()
            {
                Groups = new List<Group>();
    
                var mainGroup = new Group 
                {
                    Name = "Main", 
                    Users = new List<User> { new User("John"), new User("Bill") } 
                };
    
                var secondaryGroup = new Group
                {
                    Name = "Secondary",
                    Users = new List<User> { new User("Tom"), new User("Phil") }
                };
    
                Groups.Add(mainGroup);
                Groups.Add(secondaryGroup);
            }
    
            public IList<Group> Groups { get; private set; }
        }
    
        public class Group
        {
            public string Name { get; set; }
            public IList<User> Users { get; set; }
        }
    
        public class User
        {
            public User(string name)
            {
                Username = name;
            }
    
            public string Username { get; private set; }
        }    
    }
