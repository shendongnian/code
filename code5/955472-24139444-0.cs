    Task ThreadEval(string s, State q)
    {
        //...
        
        List<Task> tasks = new List<Task>();
        for (int i = 0; found && !accepted && i < s.Length; i++)
        {
            found = false;
            foreach (Transition t in current.transitions)
                if (t.symbol == s[i])
                {
                    tasks.Add(
                        Task.Run(
                            () => await ThreadEval(s.Substring(i+1), t.to)));
                    found = true;
                }
         }
        return Task.WhenAll(tasks);
    }
    await ThreadEval(...);
