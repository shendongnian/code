    public class User
        {
            public string FirstName { get; set; }
            virtual public void Print()
            {
                Console.WriteLine(FirstName);
            }
        }
        public class E : User
        {
            public string MiddleInitial { get; set; }
            override public void Print()
            {
                Console.WriteLine(MiddleInitial);
            }
        }
        public class F : User
        {
            public string LastName { get; set; }
            override public void Print()
            {
                Console.WriteLine(LastName);
            }
        }
    
        internal class Program
        {
            public static void Main(string[] args)
            {
                var userArray = new User[3];
                userArray[0] = new User { FirstName = "John" };
                userArray[1] = new F { LastName = "Doe" };
                userArray[2] = new E { MiddleInitial = "K" };
                PrintUsers(userArray);
            }
            private static void PrintUsers(User[] userArray)
            {
                foreach (var user in userArray)
                {
                    user.Print();
                }
            }
        }
