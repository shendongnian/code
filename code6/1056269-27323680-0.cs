     private void MensajeTablonSelected(object sender, SelectionChangedEventArgs e)
     {
        if (((LongListSelector)sender).SelectedItem != null)
        if(botonFavPulsado)
        {                
            var myItem = ((LongListSelector)sender).SelectedItem as MensajeTablon;
            if(botonAmor!=null)
            {
                if (myItem.userFav)
                {
                    botonAmor.Content = new Image
                        {
                            Source = new BitmapImage(new Uri("icons/heart.red.png", UriKind.Relative))
                        };
                }
                else
                {
                    botonAmor.Content = new Image
                    {
                        Source = new BitmapImage(new Uri("icons/heart.white.png", UriKind.Relative))
                    };
                }
            }
            botonFavPulsado = false;
            //Unselect ITEM
            ((LongListSelector)sender).SelectedItem = null;
          }
        }
