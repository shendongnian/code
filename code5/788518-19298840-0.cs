    var result = context.Groups.Where(g=>g.GroupId == groupId)
                        .Select(e=> new CustomGroup(e));
    //With your CustomGroup class should looks like this:
    [DataContract]
    public class CustomGroup  //You should consider some inheritance relationship here
       public CustomGroup(Group g){
          GroupId = g.GroupId;
          Name = g.Name;
          Description = g.Description;
          City = g.City;
          Country = g.Country;
          UsersIds = g.Users.Select(u=>u.UserId).ToList();
       }
       //....  
       [DataMember]
       public ICollection<int> UsersIds { get; set; }
    }
