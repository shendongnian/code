    public class A{
      public IEnumerable<dtoResultA> getUserStuff(int UserId){
        var result = from p in contextA.userPermission.Where(x=>x.userId = UserId)
                     select new dtoResultA{
                       userID = c.userId,
                       permissions = p,
                       benefits = getUserBenefitDetail(UserId)
                     }
      }
    }
