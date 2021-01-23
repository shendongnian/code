    private static readonly DependencyPropertyKey PointsPropertyKey =
        DependencyProperty.RegisterReadOnly(
            "Points",
            typeof(ICollectionView),
            typeof(NTab),
            new PropertyMetadata(null)
        );
    public static DependencyProperty PointsProperty = PointsPropertyKey.DependencyProperty;
    public ICollectionView Points
    {
        get { return (ICollectionView) GetValue(PointsProperty ); }
        private set { SetValue(PointsPropertyKey, value); }
    }
