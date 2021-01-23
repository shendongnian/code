    public class Program
    {
        static void Main()
        {
            User user = CreateUser("jhon", "samas");
            Console.WriteLine(user.Email);
        }
        static User CreateUser(string firstName, string lastName)
        {
            User user = new User { FirstName = firstName, LastName = lastName };
            var registerUsers = new List<User> // retrieve registered users
            {
                new User { FirstName = "jhon", LastName = "smith", Email = "jhon@domain.com" },
                new User { FirstName = "jhon", LastName = "sack", Email = "jhons@domain.com" },
                new User { FirstName = "jhon", LastName = "samuelson", Email = "jhonsa@domain.com" }
            };
            foreach (string email in user.GenerateEmails())
            {
                if (!registerUsers.Any(u => u.Email.Equals(email)))
                {
                    user.Email = email;
                    break;
                }
            }
            return user;
        }
    }
