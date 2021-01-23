    private void button_click(object sender, RoutedEventArgs e)
    {
        var name = (sender as Button).Tag.ToString();
        foreach (var item in mainlist.Items)
        {
            //if you know the button by name do this
            if(item is Button && ((Button)item).Name == "but1")
            {
                (item as Button).Opacity = 1d;
            }
            
            //set all the buttons opacity with 1 if tag is "some value" do this
            if(item is Button && ((Button)item).Tag== "Mark")
            {
                (item as Button).Opacity = 1d;
            }
            //set if you want to set all buttons opacity in the list do this
            if(item is Button)
            {
                (item as Button).Opacity = 1d;
            }
        }
    }
