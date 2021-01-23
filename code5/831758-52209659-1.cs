     private void search_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            //  box text and background to normal state if user types numbers
            search_box.Foreground = Brushes.Black;
            search_box.Background = Brushes.White;
              if (search_id.IsSelected == true)
            {
                try
                {
                    //convert while user is typing
                    if (string.IsNullOrEmpty(search_box.Text)==false)
                  Convert.ToDouble(search_box.Text);
                    search_error.Text = null;
                }
                //if user types a letter or a space or a symbol  ====>
                catch (Exception)
                {
              //  user cant type any value other than numbers as exception prevents it and clears the box text value <======
                    search_box.Text = null;
                    search_box.Foreground = Brushes.White;
                    search_box.Background = Brushes.Red;
                    search_error.Text="id is numberic value";
                }
            }
           
            }
