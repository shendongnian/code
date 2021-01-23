    AModel Get(AModel detachedModel)
    {
        using(var context = new MyContext())
        {
            return context.AModels.Single(x => x.ID == detachedModel.ID);
        }
    }
