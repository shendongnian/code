    public IQueryable<ExampleDTO> SelectDTO()
    {
        ExampleUDCRepository repository = new ExampleUDCRepository();
        return db.Example
                .Select(repository.SelectDTO().Combine((v, exampleUDCs) =>
                    new ExampleDTO()
                    {
                        ExampleID = v.ExampleID,
                        MasterGroupID = v.MasterGroupID,
                        ExampleUDCs = exampleUDCs,
                    }));
    }
