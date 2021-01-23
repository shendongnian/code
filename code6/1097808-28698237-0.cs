    public ObservableCollection<FrameworkElement> BasedMenuItems
    {
        get { return (ObservableCollection<FrameworkElement>)GetValue(BasedMenuItemsProperty); }
        set { SetValue(BasedMenuItemsProperty, value); }
    }
    public static readonly DependencyProperty BasedMenuItemsProperty =
            DependencyProperty.Register("BasedMenuItems", typeof(ObservableCollection<FrameworkElement>), typeof(ButtonsItemsControl),
            new PropertyMetadata(new ObservableCollection<FrameworkElement>()));
