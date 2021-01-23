    {
        Team team = new Team();
        team.Manager = new Person("Mr. Manager");
        team.Trainer = new Person("Mr. Trainer"); 
        Console.WriteLine ("Manager: " + team.Manager.Name);
        Console.WriteLine ("Trainer: " + team.Trainer.Name);
    }
