        List<User> Users = new List<User>(); // list of all users
        public bool IncomingRequest(string RequestingUser)//requesting user == username of the person messaging your bot
        {
            User TempUser = Users.FirstOrDefault(User => User.Username == RequestingUser);
            if (TempUser != null)// check to see if you have handled a request in the past from this user.
            {
                if ((DateTime.Now - TempUser.LastRequest).TotalSeconds >= 30) // checks if more than 30 seconds have passed between the last requests send by the user
                {
                    Users.Find(User => User.Username == RequestingUser).LastRequest = DateTime.Now; // update their last request time to now.
                    return true;
                }
                else // if less than 30 seconds has passed return false.
                {
                    return false;
                }
            }
            else // if no user is found, create a new user, and add it to the list
            {
                User NewUser = new User();
                NewUser.Username = RequestingUser;
                NewUser.LastRequest = DateTime.Now;
                Users.Add(NewUser);
                return true;
            }
        }
