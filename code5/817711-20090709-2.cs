    public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.Register(
            "SelectedItems",
            typeof(IEnumerable<ItemViewModel>),
            typeof(CustomDataGrid),
            new FrameworkPropertyMetadata(
                null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
