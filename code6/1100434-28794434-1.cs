    public abstract class ColumnAttribute : Attribute
    {
        protected internal abstract DataGridColumn CreateColumn(DataGrid dataGrid, object property);
    }
    public class DatePickerAttribute : ColumnAttribute
    {
        protected internal override DataGridColumn CreateColumn(DataGrid dataGrid, object property)
        {
            Binding binding = new Binding();
            DataGridDateColumn column = new DataGridDateColumn();
            column.Binding = binding;
            PropertyInfo propertyInfo;
            PropertyDescriptor propertyDescriptor;
            if ((propertyDescriptor = property as PropertyDescriptor) != null)
            {
                binding.Path = new PropertyPath(propertyDescriptor.Name, null);
                if (propertyDescriptor.IsReadOnly)
                {
                    binding.Mode = BindingMode.OneWay;
                    column.IsReadOnly = true;
                }
            }
            else if ((propertyInfo = property as PropertyInfo) != null)
            {
                binding.Path = new PropertyPath(propertyInfo.Name, null);
                if (!propertyInfo.CanWrite)
                {
                    binding.Mode = BindingMode.OneWay;
                    column.IsReadOnly = true;
                }
            }
            return column;
        }
    }
