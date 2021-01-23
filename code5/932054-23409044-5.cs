    public class MyApp : MyPluginApp
        {
            public static UserManager MyUserManager { get { return Manager as UserManager; } }
            public static void Start()
            {
                //Start routine
                Manager = new UserManager();
                MyUserManager.Add(new User {Id = 0, Name = "test"});
            }
        }
        public class MyPluginApp
        {
            public static IUserManager Manager { get; protected set; }
        }
