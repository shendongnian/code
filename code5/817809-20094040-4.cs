    private void Randomize()
    {
        List<UIElement> listElement = new List<UIElement>();
        while (sp.Children.Count > 0)
        {
            listElement.Add(sp.Children[0]);
            sp.Children.RemoveAt(0);
        }
        listElement.OrderBy(x => Guid.NewGuid()).ToList()
                   .ForEach(element => sp.Children.Add(element));
    }
    // randomize at startup
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        this.Randomize();
    }
    // randomize as action
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Randomize();
    }
