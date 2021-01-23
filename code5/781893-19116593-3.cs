    private IEnumerable<SomeModel> GetPersons(int categoryId) 
    {
        IEnumerable<SomeModel> persons = (from g in db.Categories
                                         join c in db.Persons on g.PersonTypeId equals c.PersonTypeId
                                         where g.CategoryId == categoryId
                                         select new SomeModel
                                         {
                                            PersonName = c.FirstName + " " + c.LastName
                                            //....etc.
                                         }).ToArray();   // <------ here
        foreach (var p in persons) 
        {
            p.IsAdmin = GetPermission(p.Email);
        }
        //end of new code
        return persons;
    }
