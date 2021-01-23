    public class LolCatRepository : ILolCatRepository
    {
     public ILolCat Get(Guid id)
     {
       return NinjectHelper.Resolve<ILolCat>();
     }
    }
