    public class B
    {
      public static IEnumerable<dtoResultB> getUserBenefitDetail(int UserId)
      {
        return stuff.....
      }
    }
    public class A
    {
      public IEnumerable<dtoResultA> getUserStuff(int UserId)
      {
        var result = from p in contextA.userPermission.Where(x=>x.userId = UserId)
                     let b = B.getUserBenefitDetail(UserId)
                     select new dtoResultA
                     {
                       userID = c.userId,
                       permissions = p,
                       benefits = b
                     }
      }
    }
