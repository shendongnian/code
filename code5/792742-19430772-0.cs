    public class A
    {
      public IEnumerable<dtoResultA> getUserStuff(int UserId)
      {
        var bInstance = new B();
        var result = from p in contextA.userPermission.Where(x=>x.userId = UserId)
                     let b = bInstance.getUserBenefitDetail(UserId)
                     select new dtoResultA
                     {
                       userID = c.userId,
                       permissions = p,
                       benefits = b
                     }
      }
    }
