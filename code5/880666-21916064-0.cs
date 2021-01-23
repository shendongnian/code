        [TestMethod]
        public void TestUpdateUser()
        {
            string username = "jdoe";
            string password = "password";
            string token = WebSecurity.CreateUserAndAccount(username, password, "jdoe@gmail.com", false);
            bool validated = WebSecurity.ValidateUser(username, password);
            Assert.IsTrue(validated, "Failed validation of user.");
            //Get user for update
            var user = WebSecurity.GetUser(username);
            //Change the user name
            username = "jdoe2";
            user.UserName = username;
            //Update the user information
            WebSecurity.UpdateUser(user);
            //Make sure we can still validate them
            validated = WebSecurity.ValidateUser(username, password);
            Assert.IsTrue(validated, "Failed validation of user after update.");
        }
