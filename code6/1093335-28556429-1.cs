    public QuestionMap()
    {
        Table("Questions");
        // here, load this in batches by 25
        BatchSize(25);
        Id(x => x.Id, "QuestionId").GeneratedBy.Identity().UnsavedValue(0);
        Map(x => x.InternalName);
        Map(x => x.IsActive, "ActiveFlag");
        HasMany(x => x.Choices)
            .KeyColumn("QuestionId")
            .AsBag()
            .Cascade
            .AllDeleteOrphan()
            .Inverse()
            // here again
            .BatchSize(25)
            .Not.LazyLoad();
    }
