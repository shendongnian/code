    public static readonly DependencyProperty RegisterAddCommandProperty = DependencyProperty.RegisterAttached("RegisterAddCommand", typeof(bool), typeof(DataGridExtensions), new PropertyMetadata(false, OnRegisterAddCommandChanged));
    public static bool GetRegisterAddCommand(DependencyObject obj)
    {
        return (bool)obj.GetValue(RegisterAddCommandProperty);
    }
    public static void SetRegisterAddCommand(DependencyObject obj, bool value)
    {
        obj.SetValue(RegisterAddCommandProperty, value);
    }
    static void OnRegisterAddCommandChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is DataGrid)
        {
            var DataGrid = sender as DataGrid;
            if ((bool)e.NewValue)
                DataGrid.CommandBindings.Add(new CommandBinding(AddCommand, AddCommand_Executed, AddCommand_CanExecute));
        }
    }
    public static readonly RoutedUICommand AddCommand = new RoutedUICommand("AddCommand", "AddCommand", typeof(DataGridExtensions));
    static void AddCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        var DataGrid = sender as DataGrid;
        var ItemsSourceType = DataGrid.ItemsSource.GetType();
        var ItemType = ItemsSourceType.GetGenericArguments().Single();
        DataGrid.Items.Add(Activator.CreateInstance(ItemType));
    }
    static void AddCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = (sender as DataGrid).CanUserAddRows;
    }
