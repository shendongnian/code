    public class UserData
    {
       public int Index{ get; set; }
       public string Name{ get; set; }
       public string PersonalNo { get; set; }
       public List<object> Details { get; set; }
    }
    public class UserDetails
    {
       public int Age;
       public string profession;
       public string gender;
    }
    public IEnumerable<Userdata> GetUserData()
    {
       var context = new DatabaseEntities();
       var Results =
           from a in context.UserData
           join b in context.UserDetails on a.Index equals b.Index into c
           select new UserData{ Index = a.Index, Name = a.Name, PersonalNo = a.PersonalNo, 
                                Details= c.ToList<object>() };
       return Results;          
    }
