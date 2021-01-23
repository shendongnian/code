    bool resulte = false;
        public string ValidateLogin(string Username, string Password)
        {
            if (Username.Equals("Admin") && Password.Equals("pass123"))
            {
                resulte = true;
                return "{\"result\":true}";
            }
            else
            {
                resulte = false;
                return "{\"result\":true}";
            }
        }
