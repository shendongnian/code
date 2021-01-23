    public IEnumerable<object> PorcentajeState(Guid id)
            {
                return _context.Sates.Where(a => a.Id == id)
                                     .GroupBy(a => a.StateId)
                                     .Select(g => new { g.Key.StateId, Count = g.Count() });
            }
