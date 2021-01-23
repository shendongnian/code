    public List<Subject> Get(int id)
    {
        using(var context = new YourDataContext())
        {
            return context.Subjects.Where(v => v.CreatedBy == id)).ToList();
        }
    }
