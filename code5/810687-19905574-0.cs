        private void favoritesListTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Book data = (sender as ListBox).SelectedItem as Book;
            int selectedid = data.unique_id;
            
            //Now find that item in the `new releases` list which has the same unique_id as the one we just retrived
            
             foreach( Book bk in newleases.Items)
             {
                  if( bk.unique_id == selectedid)
                  {
                     bk.SetFavoriteIcon = "addtofav.png"; 
                     break;
                  }
             }
         }
