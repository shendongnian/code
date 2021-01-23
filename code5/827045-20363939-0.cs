    public void TeamSearch()
    {
        Console.WriteLine("Please enter the team you wish to search for: ");
        string userinput = Console.ReadLine();          
        if (teams.Contains(userinput))
            Console.WriteLine("Success, team " + userinput);
    }
