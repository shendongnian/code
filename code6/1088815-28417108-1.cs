    public static readonly DependencyProperty ComboBoxItemsProperty =
                DependencyProperty.Register("ComboBoxItems",
                typeof(IEnumerable<object>), typeof(TestUserControl));
    public IEnumerable<object> ComboBoxItems
    {
        get
        {
            return (IEnumerable<object>)GetValue(ComboBoxItemsProperty);
        }
        set
        {
            SetValue(ComboBoxItemsProperty, value);
        }
    }
