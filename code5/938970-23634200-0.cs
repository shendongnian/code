    public class UpdatedConverter : IValueConverter
    {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataGridCell dgc = value as DataGridCell;
            if (dgc != null)
            {
                Issue data = dgc.DataContext as Issue;
                if (data != null)
                {
                    DataGridTextColumn t = dgc.Column as DataGridTextColumn;
                    if (t != null)
                    {
                        var binding = t.Binding as System.Windows.Data.Binding;
                        if (binding != null && binding.Path != null && binding.Path.Path != null)
                        {
                            string val = binding.Path.Path.ToLower();
                            if (val.StartsWith("id"))
                                return data.Id.Updated;
                            if (val.StartsWith("title"))
                                return data.Title.Updated;
                            if (val.StartsWith("body"))
                                return data.Body.Updated;
                        }
                    }
                }
            }
            return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
