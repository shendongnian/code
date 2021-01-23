    public class GenderClass : IPublicDictionary
    {
      public Dictionary<string, object> PrivateDict = new Dictionary<string, object>
      {
       {"Male", 1},
       {"Boy", 1},
       {"M", 1},
       {"Female", 2},
       {"Girl", 2},
       {"F", 2}
      };
  
      public Dictionary<string, object> Get()
      {
       return PrivateDict;
      }
    }
