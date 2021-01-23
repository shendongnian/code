    public IList<Audit> AuditsByIDs(List<int> ids)
    {
        return _db.Audits
            .Include(p => p.User)
            .Where(p => ids.Contains(p.Id)).ToList();
    }
