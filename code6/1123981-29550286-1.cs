    public class ExplodingUserRights: UserRights
    {
         public override string LookupNameByID(string id)
         {
             throw new Exception("BOOM!");
         }
    }
