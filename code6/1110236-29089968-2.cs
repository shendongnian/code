    private static void Main()
    {
        var athlete = new Person();
        bool inputIsGood = false;
           
        GetPersonName(athlete, "athlete");
        GetPersonSalary(athlete);
        Console.WriteLine("Enter the hired help. The max number of people is five. " +
            "Press any key to start.");
        Console.ReadKey();
        List<Person> hiredHelpers = new List<Person>();
        for (int i = 0; i < 5; i++)
        {
            bool addAnotherHelper =
                UserInput.GetBool(
                    string.Format("There are currently {0} helpers. " +
                        "Do you want to add another (y/n): ",
                        hiredHelpers.Count));
            if (!addAnotherHelper) break;
            Person helper = new Person();
            GetPersonName(helper, "helper");
            GetPersonSalary(helper);
                
            bool recordHelper = UserInput.GetBool("Do you want to record this " +
                "professional (y/n): ");
            if (recordHelper)
            {
                hiredHelpers.Add(helper);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Athlete's name: {0}, salary: {1:C}.", athlete, athlete.Salary);
        Console.WriteLine("Number of Hired help is: {0}", hiredHelpers.Count);
        Console.WriteLine("Hired help details:");
        hiredHelpers.ForEach(h => 
            Console.WriteLine(" - Name: {0}, Salary: {1:C}", h, h.Salary));
        Console.ReadKey();
    }
