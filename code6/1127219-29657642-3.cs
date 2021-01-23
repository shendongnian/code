    public class Program
    {
        static void Main()
        {
            User user = CreateUser("jhon", "smik");
            Console.WriteLine(user.Email);
        }
        static User CreateUser(string firstName, string lastName)
        {
            User user = new User { FirstName = firstName, LastName = lastName };
            var registeredUsers = GetSampleUsers();
            foreach (string email in user.GenerateEmails())
            {
                if (!registeredUsers.Any(u => u.Email.Equals(email)))
                {
                    user.Email = email;
                    break;
                }
            }
            return user;
        }
        static List<User> GetSampleUsers()
        {
            return new List<User>
            {
                new User { FirstName = "jhon", LastName = "smith", Email = "jhon@domain.com" },
                new User { FirstName = "jhon", LastName = "sack", Email = "jhons@domain.com" },
                new User { FirstName = "jhon", LastName = "samuelson", Email = "jhonsa@domain.com" }
            };
        }
    }
