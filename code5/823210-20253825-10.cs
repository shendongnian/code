    public IQueryable<ExampleDTO> SelectDTO()
    {
        ExampleUDCRepository repository = new ExampleUDCRepository();
        var generateUDCExpression = repository.SelectDTO();
        return db.Example
            .AsExpandable()
            .Select(v =>
                new ExampleDTO()
                {
                    ExampleID = v.ExampleID,
                    MasterGroupID = v.MasterGroupID,
                    ExampleUDCs = generateUDCExpression.Invoke(v),
                });
    }
