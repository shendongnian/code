     class Person
     {
          public Person(string str)
          {
              int pos = str.LastIndexOf('(');
              Name = str.Substring(0, pos - 1);
              WorkerId = str.Substring(pos + 1).TrimEnd(')');
          }
    
          public string Name;
          public string WorkerId;
     }
