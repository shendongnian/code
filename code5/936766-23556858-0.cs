        public class UserDetails
        {
            public string Name {get;set;}
            public string Age {get;set;}
            public string Mileage {get;set;}
        }
        public static UserDetails GetInput()
        {
            //declared variables
            //string userInput;
            //string outputTitle;
            var userD = new UserDetails();
            Console.Write("Enter your name: ");
            userD.Name = Console.ReadLine();
            Console.Write("Enter your age: ");
            userD.Age = Console.ReadLine();
            Console.Write("Enter the Gas Mileage: ");
            userD.Mileage = Console.ReadLine();
            return userD;
        }
