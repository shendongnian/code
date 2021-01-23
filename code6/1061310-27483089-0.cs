    private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var selecteditem = MainLongListSelector.SelectedItem as LongListData; 
                MessageBox.Show(selecteditem.ImgText.ToString());
            } 
