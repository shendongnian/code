        static void Main(string[] args)
        {
            var users = UserInfoProvider.GetUsers();
            foreach (var user in users)
            {
                user.SetValue("myTestString", "test");
                user.Generalized.SetObject();
            }
        }
