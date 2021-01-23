    namespace InstagramLogin.Code
    {
        public class UserLogged
        {
            public string id { get; set; }
            public string username { get; set; }
            public string full_name { get; set; }
            public string profile_picture { get; set; }
        }
    
        public class AuthUserApiToken
        {      
            public string access_token { get; set; }
            public UserLogged user { get; set; }
        }
    }
