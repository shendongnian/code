    public CoursModel Get(int id)
    {
        using (SSDEntities Entity = new SSDEntities())
        return Entity.Courses.SingleOrDefault<Cours>(a => a.ID == id)
        .Select(x=> new CoursModel()
             { MAP STUFF HERE });
    }
