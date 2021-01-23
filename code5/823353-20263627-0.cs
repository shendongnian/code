    [HttpGet]
    [LinqToQueryable]
    public IEnumerable<SomeViewModel> SomeAction()
    {
        return _databaseContext.Entities
                               .Where(e => e.SomeProp = "Example")
                               .Project()
                               .To<SomeViewModel>();
    }
