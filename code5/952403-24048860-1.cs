    private void DetailsSourceChanged(object sender, EventArgs e)
    {
        if (DetailsGrid.Items.Count > 0)
        {
            ((IEditableCollectionView)DetailsGrid.Items).NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtBeginning;
        }
    }
