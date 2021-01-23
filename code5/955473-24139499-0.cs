    List<Task> runningEvals = new List<Task>();
    
    async Task ThreadEval(string s, State q)
    {            
        if (s.Length == 0 && q.IsFinal)
        {
    		Task.WaitAll(runningEvals.ToArray()); // wait for all tasks to finish
    		runningEvals.Clear();
    		
            accepted = true;
            return;
        }
    
        bool found = true;            
        State current = q;
    
        for (int i = 0; found && !accepted && i < s.Length; i++)
        {
            found = false;
            foreach (Transition t in current.transitions)
                if (t.symbol == s[i])
                {
                    // start a task and add it to the "running tasks" list
    				var task = Task.Run(() => ThreadEval(s.Substring(i+1), t.to));
    				runningEvals.Add(task);
                    found = true;
                }
         }
    }
