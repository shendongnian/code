    var data = _dataService
        .GetType()
        .GetMethod("GetCollectionQueryModel")
        .MakeGenericMethod(t)
        .Invoke(_dataService, new object[]
        {
            Query.And(
                Query.EQ("IsActive", true),
                Query.GTE("CreateDate", DateTime.Now.AddDays(-7)),
                Query.LTE("CreateDate", DateTime.Now.AddHours(23))))
            .OrderByDescending(c => c.CreateDate);
        });
