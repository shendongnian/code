      HashSet<String> hash = new HashSet<string>();
      string input = "TEST";
      bool found = false;
    
      foreach(string item in arr)
      {
          if (item.Equals(input))
          {
              if (hash.Contains(item))
              {
                  Console.WriteLine("Already Taken");
              }
              else
              {
                  hash.Add(item);
              }
              found = true;
              break;
          }
       }
      if (!found)
      {
          Console.WriteLine("Invalid Input");
      }
