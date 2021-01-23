    private void GenerateId(IEnumerable<BaseEntity> entities) // or IReadOnlyCollection<BaseEntity>, or IReadOnlyList<BaseEntity>, etc.
    {
        foreach (BaseEntity e in entities)
        {
           e.Id = _baseDao.GetNextId();
        }
    }
