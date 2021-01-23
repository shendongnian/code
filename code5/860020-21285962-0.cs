    public static readonly DependencyProperty DataRefreshedProperty = DependencyProperty.Register(
      "DataRefreshed",
      typeof(bool),
      typeof("typeof yourcontrol here "),
      new FrameworkPropertyMetadata(null,
          FrameworkPropertyMetadataOptions.AffectsRender, 
          new PropertyChangedCallback(OnDataRefreshedChanged)
      )
    );
    public bool DataRefreshed
    {
      get { return (bool)GetValue(DataRefreshedProperty); }
      set { SetValue(DataRefreshedProperty, value); }
    }
