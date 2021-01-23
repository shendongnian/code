    public static readonly DependencyProperty ElementsSourceProperty =
            DependencyProperty.Register(
            "ElementsSource", typeof(IList<Type>), typeof(ListViewCustomControl),
            null);
    public IList<Type> ElementsSource
    {
        get { return (IList<Type>)GetValue(ElementsSourceProperty); }
        set { SetValue(ElementsSourceProperty, value); }
    }
