    public enum LoginError
            {
                None = 0,
                InvalidUsername,
                InvalidPassword,
            }
        
            public enum CustomerError
            {
                None = 0,
                NameRequired,
                SurnameRequired,
            }
        
            private static void Main(string[] args)
            {
                Dictionary<Enum, string> myErrorDictionary = new Dictionary<Enum, string>();
        
                myErrorDictionary.Add(LoginError.None, "This is None from Login Error");
                myErrorDictionary.Add(LoginError.InvalidUsername, "Invalid username");
                myErrorDictionary.Add(LoginError.InvalidPassword, "Invalid Password");
        
                myErrorDictionary.Add(CustomerError.None, "This is None from Custom Error");
                myErrorDictionary.Add(CustomerError.NameRequired, "Name Required");
                myErrorDictionary.Add(CustomerError.SurnameRequired, "Surname Required");
        
                Console.WriteLine(myErrorDictionary[LoginError.None]);
                Console.WriteLine(myErrorDictionary[CustomerError.None]);
        
                Console.Read();
            }
