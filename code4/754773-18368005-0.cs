            static void Main(string[] args)
        {
            CreateApp();
            RenameApp();
            EditApp();
            DeleteApp();
        }
        private static void EditApp()
        {
            using (ServerManager mgr = new ServerManager())
            {
                Application app = mgr.Sites["Default Web Site"].Applications["/TestAppNew"];
                VirtualDirectory vdir = app.VirtualDirectories["/"];
                vdir.UserName = "SomeUser";
                vdir.Password = "SomePassword";
                mgr.CommitChanges();
            }
        }
        private static void DeleteApp()
        {
            using (ServerManager mgr = new ServerManager())
            {
                Application app = mgr.Sites["Default Web Site"].Applications["/TestAppNew"];
                mgr.Sites["Default Web Site"].Applications.Remove(app);
                mgr.CommitChanges();
            }
        }
        private static void RenameApp()
        {
            using (ServerManager mgr = new ServerManager())
            {
                Application app = mgr.Sites["Default Web Site"].Applications["/TestApp"];
                app.Path = "/TestAppNew";
                mgr.CommitChanges();
            }
        }
        private static void CreateApp()
        {
            using (ServerManager mgr = new ServerManager())
            {
                mgr.Sites["Default Web Site"].Applications.Add("/TestApp", @"c:\inetpub\wwwroot");
                mgr.CommitChanges();
            }
        }
