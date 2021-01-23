        string solverType = "GLPK_MIXED_INTEGER_PROGRAMMING";
        Solver solver = Solver.CreateSolver("IntegerProgramming", solverType);
        if (solver == null)
        {
          Console.WriteLine("Could not create solver " + solverType);
          return;
        }
        // x1 and x2 are integer non-negative variables.
        Variable x1 = solver.MakeIntVar(0.0, double.PositiveInfinity, "x1");
        Variable x2 = solver.MakeIntVar(0.0, double.PositiveInfinity, "x2");
    
        // Minimize x1 + 2 * x2.
        Objective objective = solver.Objective();
        objective.SetMinimization();
        objective.SetCoefficient(x1, 1);
        objective.SetCoefficient(x2, 2);
    
        // 2 * x2 + 3 * x1 >= 17.
        Constraint ct = solver.MakeConstraint(17, double.PositiveInfinity);
        ct.SetCoefficient(x1, 3);
        ct.SetCoefficient(x2, 2);
    
        int resultStatus = solver.Solve();
    
        // Check that the problem has an optimal solution.
        if (resultStatus != Solver.OPTIMAL)
        {
          Console.WriteLine("The problem does not have an optimal solution!");
          return;
        }
    
        Console.WriteLine("Problem solved in " + solver.WallTime() +
                          " milliseconds");
    
        // The objective value of the solution.
        Console.WriteLine("Optimal objective value = " + objective.Value());
    
        // The value of each variable in the solution.
        Console.WriteLine("x1 = " + x1.SolutionValue());
        Console.WriteLine("x2 = " + x2.SolutionValue());
    
        Console.WriteLine("Advanced usage:");
        Console.WriteLine("Problem solved in " + solver.Nodes() +
                          " branch-and-bound nodes");
