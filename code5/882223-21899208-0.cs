    void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if((sender as LongListSelector).SelectedItem == null){
                 return;
                }
                SelectedItem = base.SelectedItem;
                (sender as LongListSelector).SelectedItem = null;   
            }
