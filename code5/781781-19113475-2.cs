    public int VisibleCount
    {
        get { return Children.OfType<UIElement>().Count(c => c.Visibility == 
                  Visibility.Visible); }
    }
