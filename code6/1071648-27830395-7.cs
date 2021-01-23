    Solver solver = new Solver("Volsay", Solver.CLP_LINEAR_PROGRAMMING);
    
    //
    // Variables
    //
    
    Variable Gas = solver.MakeNumVar(0, 100000, "Gas");
    Variable Chloride = solver.MakeNumVar(0, 100000, "Cloride");
    
    Constraint c1 = solver.Add(Gas + Chloride <= 50);
    Constraint c2 = solver.Add(3 * Gas + 4 * Chloride <= 180);
    
    solver.Maximize(40 * Gas + 50 * Chloride);
    
    int resultStatus = solver.Solve();
    
    if (resultStatus != Solver.OPTIMAL) {
      Console.WriteLine("The problem don't have an optimal solution.");
      return;
    }
    
    Console.WriteLine("Objective: {0}", solver.ObjectiveValue());
    
    Console.WriteLine("Gas      : {0} ReducedCost: {1}",
                      Gas.SolutionValue(),
                      Gas.ReducedCost());
    
    Console.WriteLine("Chloride : {0} ReducedCost: {1}",
                      Chloride.SolutionValue(),
                      Chloride.ReducedCost());
