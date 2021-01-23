    private string GetRuleByName(string name, List<string> rules)
    {
        if(rules != null)
        {
            List<string> todo = new List<string>();
            todo.AddRange(rules);
    
            while(todo.Count != 0) // <-- Minor mod here
            {
                string r = todo[0]; 
                todo.RemoveAt(0);
    
                // ...
            }
        }
    }
