    private void lbxCategory_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        lbxBooks.Items.Refresh();
        CollectionViewSource collectionView = Resources["SortedList"] as CollectionViewSource;
        if(collectionView.View != null) collectionView.View.Refresh();
    }
    private void CollectionViewSource_Filter_1(object sender, FilterEventArgs e)
    {
        XmlElement element = e.Item as XmlElement;
        e.Accepted = ((XmlElement)lbxCategory.SelectedItem).Attributes["name"].Value == element.ParentNode.Attributes["name"].Value;
    }
