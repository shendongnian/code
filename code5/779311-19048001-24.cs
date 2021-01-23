    private People _Person;
    //lazy loaded property
    private People Person
    {
        get
        {
            if (_Person == null)
                using (PeopleEntities ctx = new PeopleEntities())
                    _Person = GetPerson(ctx);
            
            //returning a Person that isn't updateable because we've disposed of the context    
            return _Person;
        }
    }
    //Retrieve an updateable person
    private static object GetPerson(PeopleEntities ctx)
    {
        return (from a in ctx.People
                where a.PersonID == int.Parse(Session["PersonID"]
                select a).FirstOrDefault();
    }
