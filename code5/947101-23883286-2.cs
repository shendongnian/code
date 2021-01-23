    private void GenerateId<T>(ICollection<T> entities)
      where T: BaseEntity
    {
        foreach (var e in entities)
        {
           e.Id = _baseDao.GetNextId();
        }
    }
