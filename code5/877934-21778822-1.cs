     class FirstColumnConverter:IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                DataGrid dg = value as DataGrid;
                var totalItems = dg.Items.Count;
                int summedValue = 0;
    
                for (int i = 0; i < totalItems-1; i++)
                {
                        var currentItem = (Customer) dg.Items.GetItemAt(i);
                        summedValue += currentItem.ID;
                }
    
                return summedValue;   
            }
        }
