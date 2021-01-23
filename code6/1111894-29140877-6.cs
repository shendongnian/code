        public static User userLogin(string username, string password)
        {
            User U = DAL.userLogin(username, password);
            if (string.IsNullOrEmpty(U.Name))
                throw new Exception("Incorrect login details");
            return U;
        }
