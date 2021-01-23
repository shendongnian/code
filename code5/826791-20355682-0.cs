     public void searchResult_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button; //Assuming your trigger is a button UI element.
            if (button != null)
            {
                var place = button.DataContext as TestMap.Classes.Global.Place;
                if (place != null)
                {
                    Classes.Global.posx = place.posx;
                    Classes.Global.posy = place.posy;
                }
            }
            NavigationService.GoBack();
        }
