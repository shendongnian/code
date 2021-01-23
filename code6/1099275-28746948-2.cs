    public class NameId
    {
         public int Id {get; set;}
         public string Name {get; set;}
    }
    public class UserNamesResponse
    {
         public List<NameId> Names {get; set;}
         public List<NameId> Profiles {get; set;}
    }
