      HashSet<String> hash = new HashSet<string>();
      string inputed = "TEST";
      bool found = false;
    
      foreach(String item in arr)
      {
          if (item.equals(input))
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
