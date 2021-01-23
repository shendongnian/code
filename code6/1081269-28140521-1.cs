     public IList<TTag> FindAllTTag()
    {
        using(var dbContext = new PAMEntities())
        {
            var res = (from c in dbContext.TypeCollectionSets
                       join t in dbContext.TypeCollectionSet_TTag
                       on c.Id equals t.Id
                       select c).ToList().Cast<TTag>().ToList();
           return res;
        }
    }
