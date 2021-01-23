    public virtual List<T> GetAll()
    {
        using (var db = new Entities())
        {
            return db.Set<T>().ToList();
        }
    }
