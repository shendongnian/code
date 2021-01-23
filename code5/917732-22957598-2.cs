    public class LolCatRepository : ILolCatRepository
    {
     public List<ILocalCat> _localCats;
     // ninject will inject this list due to the chain of dependency.
     // if it fails, then go with option #1.
     public LolCatRepository(List<ILocalCat> localCats)
     {
      this._localCats = localCats;
     }
  
     public ILolCat Get(Guid id)
     {
       return this._localCats.FirstOrDefault(lc => lc.Id == id);
     }
     // similarly GetAll
    }
