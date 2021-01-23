        for (int i = 0; i < l2.Count; i++)
        {
             if (l1.Contains(l2[i])) {
                  Console.WriteLine("value {0} present in l1", l2[i]);
             }
             else {
                  Console.WriteLine("value {0} is not present in l1", l2[i]);
             }
        }
        
        for (int i = 0; i < l1.Count; i++)
        {
            if (l2.Contains(l1[i]))  {
                Console.WriteLine("value {0} present in l2", l2[i]);
            }
            else {
                Console.WriteLine("value {0} is not present in l2", l2[i]);
            }
        }
