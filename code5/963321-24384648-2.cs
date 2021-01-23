    public class MyLoginService : Service
    {
        public LoginResultModel Post(LoginRequest request)
        {
            // Your login logic here
            return new LoginResultModel {
                Country = new Country { Name = "United States", A2 = "Something", Code = 1, PhonePrefix = 555},
                Avatars = new Avatars { Small = "small.png", Medium = "medium.png", Large = "large.png" },
                RootObject = new RootObject { 
                    CID = 123,
                    Username = "",
                    ...
                }
            };
        }
    }
