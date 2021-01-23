    {
        Team team = new Team();
        team.Manager = new Person("Mr. Manager");
        PrettyPrinter p = new PrettyPrinter();
        Console.WriteLine ("Manager: " + p.GetNameOrNone(team.Manager));
        Console.WriteLine ("Trainer: " + p.GetNameOrNone(team.Trainer));
    }
