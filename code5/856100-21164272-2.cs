    public static class CustomColumnHeadersProperty
    {
        public static DependencyProperty ItemTypeProperty = DependencyProperty.RegisterAttached(
            "ItemType",
            typeof(Type),
            typeof(CustomColumnHeadersProperty),
            new PropertyMetadata(OnItemTypeChanged));
        public static void SetItemType(DependencyObject obj, Type value)
        {
            obj.SetValue(ItemTypeProperty, value);
        }
        public static Type GetItemType(DependencyObject obj)
        {
            return (Type)obj.GetValue(ItemTypeProperty);
        }
        private static void OnItemTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var dataGrid = sender as DataGrid;
            if (args.NewValue != null)
                dataGrid.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            else
                dataGrid.AutoGeneratingColumn -= dataGrid_AutoGeneratingColumn;
        }
        static void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var type = GetItemType(sender as DataGrid);
            var displayAttribute = type.GetProperty(e.PropertyName).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            if (displayAttribute != null)
                e.Column.Header = displayAttribute.Name;
        }
    }
    <DataGrid x:Name="grid" local:CustomColumnHeadersProperty.ItemType="{x:Type local:MyClass}"/>
