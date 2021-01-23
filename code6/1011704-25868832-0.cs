    public static readonly DependencyProperty ItemsSource2Property =
       DependencyProperty.Register(
       "ItemsSource2",
       typeof(IEnumerable),
       typeof(FilteredComboBox),
       new UIPropertyMetadata((IEnumerable)null, new PropertyChangedCallback(OnItemsSource2Changed)));
    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable ItemsSource2
    {
        get { return (IEnumerable)GetValue(ItemsSource2Property); }
        set
        {
            if (value == null)
            {
                ClearValue(ItemsSource2Property);
            }
            else
            {
                SetValue(ItemsSource2Property, value);
            }
        }
    }
    private static void OnItemsSource2Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var ic = (FilteredComboBox)d;
        var oldValue = (IEnumerable)e.OldValue;
        var newValue = (IEnumerable)e.NewValue;
        if (newValue != null)
        {
            //Prevents the control to select the first item automatically
            ic.IsSynchronizedWithCurrentItem = false;
            var viewSource = new CollectionViewSource { Source = newValue };
            ic.ItemsSource = viewSource.View;
        }
        else
        {
            ic.ItemsSource = null;
        }
    }
