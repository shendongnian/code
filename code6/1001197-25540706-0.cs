    private void TextBox_TextChanged(object sender, TextChangedEven)
        {
            ICollectionView view = lvTest.ItemsSource as ICollectionView;
            string txtToSearch = searchTextBox.Text;
            view.Filter = (p) => { return ((Music)p).ArtistName.Contains(txtToSearch); };
            view.Refresh();
        } 
         
