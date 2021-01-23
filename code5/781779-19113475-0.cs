    public int VisibleCount
    {
        get { return Children.OfType<UIElement>().Where(c => c.Visibility == 
    Visibility.Visible).Count(); }
    }
