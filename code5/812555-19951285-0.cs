    Tuple<string,string> ReturnNames(Team team)
    {
      var trainerName = (team.TeamTrainer == null)? "None" : team.TeamTrainer.TrainerName;
      var managerName = (team.TeamTrainer == null)? "None" : team.TeamManager.ManagerName;
      return Tuple.Create(trainerName, managerName);
    }
    
    var tuple = ReturnNames(team);
    Console.WriteLine ("Manager: " + tuple.Item1 );
    Console.WriteLine ("Trainer: " + tuple.Item2 );
