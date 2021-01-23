    public string FirstColumnBindingPropertyName
    {
        get { return (string)GetValue(FirstColumnBindingPropertyNameProperty); }
        set { SetValue(FirstColumnBindingPropertyNameProperty, value); }
    }
    
    public static readonly DependencyProperty FirstColumnBindingPropertyNameProperty =
        DependencyProperty.Register("FirstColumnBindingPropertyName", typeof(string), typeof(GroupPanel), new UIPropertyMetadata(null, new PropertyChangedCallback(OnFirstColumnBindingPropertyNameChanged)));
    
            
    private static void OnFirstColumnBindingPropertyNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        GroupPanel groupPanel = (GroupPanel)dependencyObject;
        DataGridTextColumn dataGridTextColumn = groupPanel.mainGrid.Columns[0] as DataGridTextColumn;
        if (args.NewValue == null)
        {
            dataGridTextColumn.Binding = null;
        }
        else
        {
            dataGridTextColumn.Binding = new Binding(Convert.ToString(args.NewValue));
        }
    }
