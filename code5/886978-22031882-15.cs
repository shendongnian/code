    List<Func<int>> actions = new List<Func<int>>();
    int variable = 0;
    while (variable < 3)
    {
        actions.Add(() => variable * variable);
        ++ variable;
    }
    
    foreach (var act in actions)
    {
        Console.WriteLine(act.Invoke());
    }
