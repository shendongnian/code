    public List<Subject> Get(int id)
    {
        IQueryable<Subject> query;
        return query = from Subjects in db.SubjectContext.Where(v => v.CreatedBy == id).ToList();
    }
