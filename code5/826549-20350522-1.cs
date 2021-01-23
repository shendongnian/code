        var namesFound = new List<string>();
        for (int i = 0; i < tests.Count; i++)
        {
           if (!namesFound.Contains(tests[i].UserName))
           {
               namesFound.Add(tests[i].UserName);
           }
           else
           {
               tests.Remove(tests[i]);
               i--;
           }
        }
