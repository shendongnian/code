    // GET: api/Actors
    public IQueryable<Actor> GetActors(bool oscarWinner = false)
    {
        return db.Actors.Where(actor=>actor.OscarWinner == oscarWinner);
    }
