    private static void UnityRegistration(IUnityContainer container)
    {
        container.RegisterType(
            typeof(IDataTransformerSelector<,>), 
            typeof(DataTransformerSelector<,>));
        container.RegisterType(
            typeof(IDataTransformerManager<,>),
            typeof(DataTransformerManager<,>));
        container.RegisterType<IDataTransformer<EntitiesModel>, TrackCreatedTransformer>
            ("TrackCreatedTransformer");
        container.RegisterType<IDataTransformer<EntitiesModel>, TrackChangedTransformer>
            ("TrackChangedTransformer");
        container.RegisterType<IDataTransformer<EntitiesModel>, TrackClosedTransformer>
            ("TrackClosedTransformer");
        container.RegisterType<IDataTransformer<EntitiesModel>, TrackSignedTransformer>
            ("TrackSignedTransformer");
    }
