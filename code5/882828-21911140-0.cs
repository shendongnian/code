    public void getElements(object Sender, RoutedEventArgs e)
    {
        DependencyObject dpobj = e.OriginalSource as DependencyObject;
        string name = dpobj.GetValue(FrameworkContentElement.NameProperty) as string;
        Console.WriteLine("Element Clicked: " + name);
    }
