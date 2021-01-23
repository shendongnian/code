    var newData = ExampleDataFactory.NewData<ServicesAndFeaturesInfo>();
    newData.Add(x => x.Property1.Property2.Property3.Property4, true);
    newData.Add(...);
    ...
    newData.Get();
