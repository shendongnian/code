    var listOfData = new List<TypeData>{ 
        new TypeData {
            Name = "TestData",
            Data = new List<Data> 
            {
                new Data { Value = 1.5 }, new Data { Value = 2.4 }, new Data { Value = 1.2 },  new Data(),
                new Data { Value = 0.7 }, new Data { Value = -4.7 }, new Data { Value = 0.0 }, new Data { Value = 4711}
            }
        }
    };
    foreach (var td in listOfData)
    {
        foreach (var data in td.Data.Take(10))
        {
            data.Value = 4711.4711;
        }
    }
    foreach (var td in listOfData)
    {
        foreach (var data in td.Data.Take(10))
        {
            data.RevertOperation();
        }
    }
