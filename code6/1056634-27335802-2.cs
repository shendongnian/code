    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int Age
        {
            // Calculate the person's age based on the current date and their birthday
            get
            {
                int years = DateTime.Today.Year - DateOfBirth.Year;
                // If they haven't had the birthday yet, subtract one
                if (DateTime.Today.Month < DateOfBirth.Month ||
                    (DateTime.Today.Month == DateOfBirth.Month && 
                     DateTime.Today.Day < DateOfBirth.Day)) 
                {
                    years--;
                }
                return years;
            }
        }
    }
    private static void GenericTester()
    {
        Console.Write("How many persons you want to add?: ");
        string input = Console.ReadLine();
        int numPeople = 0;
        // Make sure the user enters an integer by using TryParse
        while (!int.TryParse(input, out numPeople))
        {
            Console.Write("Invalid number. How many people do you want to add: ");
            input = Console.ReadLine();
        }
        var people = new List<Person>();
        for (int i = 0; i < numPeople; i++)
        {
            // Here you can give each person a custom name based on a number
            people.Add(new Person { Name = "Person" + (i + 1) });
        }
        Console.WriteLine("Great! We've created {0} people. Their temporary names are:", 
            numPeople);
        people.ForEach(person => Console.WriteLine(person.Name));
        Console.WriteLine("Enter the name of the person you want to edit: ");
        input = Console.ReadLine();
        // Get the name of a person to edit from the user
        while (!people.Any(person => person.Name.Equals(input, 
            StringComparison.OrdinalIgnoreCase)))
        {
            Console.Write("Sorry, that person doesn't exist. Please try again: ");
            input = Console.ReadLine();
        }
        // Grab a reference to the person the user asked for
        Person selectedPerson = people.First(person => person.Name.Equals(input, 
            StringComparison.OrdinalIgnoreCase));
        // Ask for updated information:
        Console.Write("Enter a new name (or press enter to keep the default): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            selectedPerson.Name = input;
        }
        Console.Write("Enter {0}'s birthday (or press enter to keep the default) " + 
            "(mm//dd//yy): ", selectedPerson.Name);
        input = Console.ReadLine();
        DateTime newBirthday = selectedPerson.DateOfBirth;
        if (!string.IsNullOrWhiteSpace(input))
        {
            // Make sure they enter a valid date
            while (!DateTime.TryParse(input, out newBirthday) && 
                DateTime.Today.Subtract(newBirthday).TotalDays >= 0)
            {
                Console.Write("You must enter a valid, non-future date. Try again: ");
                input = Console.ReadLine();
            }
        }
        selectedPerson.DateOfBirth = newBirthday;
        Console.Write("Enter {0}'s address (or press enter to keep the default): ", 
            selectedPerson.Name);
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            selectedPerson.Address = input;
        }
        Console.WriteLine("Thank you! Here is the updated information:");
        Console.WriteLine(" - Name ............ {0}", selectedPerson.Name);
        Console.WriteLine(" - Address ......... {0}", selectedPerson.Address);
        Console.WriteLine(" - Date of Birth ... {0}", selectedPerson.DateOfBirth);
        Console.WriteLine(" - Age ............. {0}", selectedPerson.Age);
    }
