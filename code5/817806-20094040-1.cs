    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // empty the stackPanel
        sp.Children.Clear();
        // create a list of RadioButtons
        List<UIElement> listElement = new List<UIElement>();
        listElement.Add(rb1);
        listElement.Add(rb2);
        listElement.Add(rb3);
        listElement.Add(rb4);
        // Randomize the list and fill the stackpanel with linq
        listElement.OrderBy(x => Guid.NewGuid()).ToList()         // randomize list
                   .ForEach(element => sp.Children.Add(element)); // add each radiobutton
    }
