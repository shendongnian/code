    ((IEditableCollectionView)DetailsGrid.Items).NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtBeginning;
    var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
    if (dpd != null)
    {
        dpd.AddValueChanged(DetailsGrid, DetailsSourceChanged);
    }
