    public MainWindow()
        {
            InitializeComponent();
            myDataGrid.AutoGeneratingColumn += DataGridUtilities.dataGrid_AutoGeneratingColumn;
        }
    public static class DataGridUtilities
    {
        public static void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!IsTypeOrNullableOfType(e.PropertyType, typeof (String)) &&
                !IsNullableOfValueType(e.PropertyType))
                e.Cancel = true;
            else if (IsTypeOrNullableOfType(e.PropertyType, typeof (DateTime)))
            {
                DataGridTemplateColumn col = new DataGridTemplateColumn();
                col.Header = e.Column.Header;
                FrameworkElementFactory datePickerFactoryElem = new FrameworkElementFactory(typeof (DatePicker));
                Binding dateBind= new Binding(e.PropertyName);
                dateBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                dateBind.Mode = BindingMode.TwoWay;
                datePickerFactoryElem.SetValue(DatePicker.SelectedDateProperty, dateBind);
                datePickerFactoryElem.SetValue(DatePicker.DisplayDateProperty, dateBind);
                DataTemplate cellTemplate = new DataTemplate();
                cellTemplate.VisualTree = datePickerFactoryElem;
                col.CellTemplate = cellTemplate;
                e.Column = col;//Set the new generated column
            }
        }
        private static bool IsTypeOrNullableOfType(Type propertyType, Type desiredType)
        {
            return (propertyType == desiredType || Nullable.GetUnderlyingType(propertyType) == desiredType);
        }
        private static bool IsNullableOfValueType(Type propertyType)
        {
            return (propertyType.IsValueType ||
                    (Nullable.GetUnderlyingType(propertyType) != null &&
                     Nullable.GetUnderlyingType(propertyType).IsValueType));
        }
    }
