    public IEnumerable<object> PorcentajeState(Guid id)
    {
        return from a in _context.Sates
               where a.Id == id
               group a by a.StateId into g
               select new { a.Key, Count = g.Count() };
    }
