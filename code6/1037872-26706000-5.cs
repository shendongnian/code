    // I made with a thickness of 100, so we can see the border better
    Popup p;
    p = new Popup
    {
        Width = 480,
        Height = 580,
        VerticalOffset = 0
    };
    Border b = new Border();
    b.BorderBrush = new SolidColorBrush(Colors.Red);
    b.BorderThickness = new Thickness(100);
    b.Margin = new Thickness(10, 10, 10, 10);
    b.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
    b.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
    p.Child = b;
    // add it to the same level as the pivot to over ride pivot
    this.ContentPanel.Children.Add(p);
    p.IsOpen = true;
