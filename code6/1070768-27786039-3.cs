        public bool Success { get; private set; }
        public static bool Authenticate()
        {
            var login = new Login();
            login.ShowDialog();
            
            return login.Success;
        }
