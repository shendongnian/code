    internal static class UserLogUtil
    {
        public static bool LogUser(IServiceBase authService, string userName, string password)
        {
            var userService = new UserService(); //This can be a webservice; or, you can just call your repository from here
            var loggingResponse = (UserLogResponse)userService.Post(new LoggingUser { UserName = userName, Password = password });
            if (loggingResponse.User != null && loggingResponse.ResponseStatus == null)
            {
                var session = (CustomUserSession)authService.GetSession(false);
                session.DisplayName = loggingResponse.User.FName.ValOrEmpty() + " " + loggingResponse.User.LName.ValOrEmpty();
                session.UserAuthId = userName;
                session.IsAuthenticated = true;
                session.Id = loggingResponse.User.UserID.ToString();
                // add roles and permissions
                //session.Roles = new List<string>();
                //session.Permissions = new List<string>();
                //session.Roles.Add("Admin);
                //session.Permissions.Add("Admin");
               
                return true;
            }
            else
                return false;
        }
    }
    
