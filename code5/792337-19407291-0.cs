    private void FavoriButton_Click_1(object sender, RoutedEventArgs e)
         {    
             for( var i = 0 ; i<itemGridView.Items.Count ; i++)
             {
                 (itemGridView.ItemContainerGenerator.ContainerFromIndex(i) as GridViewItem).IsSelected = true;
             }
         }
