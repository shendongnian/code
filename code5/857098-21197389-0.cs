    public static T GetNewData<T>(params Expression<Action<T>>[] actions)
                    where T : class, new() {
        ...
    }
    ...
    ExampleDataFactory.GetNewData<ServicesAndFeaturesInfo>(
        x => x.Property1.Property2.Property3.Property4 = true);
