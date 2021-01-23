    public List<Subject> Get(int id)
    {
        using(var context = new YourDataContext())
        {
            var queryResult = (from Subjects in db.SubjectContext.Where(v => v.CreatedBy == id)).ToList();
            return queryResult;
        }
    }
