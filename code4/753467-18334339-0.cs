    private static readonly DependencyPropertyKey ComboBoxVisiblityPropertyKey
        = DependencyProperty.RegisterReadOnly("ComboBoxVisiblity", typeof(int), 
        typeof(SearchUserControl), new PropertyMetadata(Visibility.Collapsed));
    public static readonly DependencyProperty ComboBoxVisiblityProperty
        = ComboBoxVisiblityPropertyKey.DependencyProperty;
    public int ComboBoxVisiblity
    {
        get { return (int)GetValue(ComboBoxVisiblityProperty); }
        protected set { SetValue(ComboBoxVisiblityPropertyKey, value); }
    }
