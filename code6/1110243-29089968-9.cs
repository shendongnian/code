    private static void GetPersonName(Person person, string typeOfPerson)
    {
        if (person == null) throw new ArgumentNullException("person");
        if (string.IsNullOrWhiteSpace(typeOfPerson)) typeOfPerson = "person";
        bool inputIsGood = false;
        while (!inputIsGood)
        {
            person.FirstName = UserInput.GetString(
                string.Format("Please enter the first name of the {0}: ", typeOfPerson));
            person.LastName = UserInput.GetString(
                string.Format("Please enter the last name of the {0}: ", typeOfPerson));
            Console.WriteLine("You entered: {0}", person);
            inputIsGood = UserInput.GetBool("Is that correct (y/n): ");
        }
    }
    private static void GetPersonSalary(Person person)
    {
        bool inputIsGood = false;
        while (!inputIsGood)
        {
            person.Salary = UserInput.GetDecimal(
                string.Format("Enter the salary of {0}: $", person));
            Console.WriteLine("You entered: {0:C}", person.Salary);
            inputIsGood = UserInput.GetBool("Is that correct (y/n): ");
        }
    }
