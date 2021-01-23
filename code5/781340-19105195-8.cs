    public class GenderClass : IPublicDictionary<int>
    {
     public static Dictionary<string, int> PublicDict = new Dictionary<string, int>
     {
      {"Male", 1},
      {"Boy", 1},
      {"M", 1},
      {"Female", 2},
      {"Girl", 2},
      {"F", 2}
     };
  
     public Dictionary<string, int> PublicDictionary
     {
      get { return PublicDict; }
     }
    }
