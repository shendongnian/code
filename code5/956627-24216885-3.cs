    public class DataGridBehaviors : Behavior<DataGrid>
    {
        ...
        void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyClass.Instance.SelectedMarkers.Clear();
            //updated item count
            MyClass.Instance.ItemCount = this.AssociatedObject.Items.Count;
            foreach (object o in this.AssociatedObject.SelectedItems)
                MyClass.Instance.SelectedMarkers.Add(this.AssociatedObject.Items.IndexOf(o));
        }
    }
    //removed ItemsControlBeahviors
    public class MyClass : INotifyPropertyChanged
    {
        ...
        //added item count property
        public int ItemCount { get; set; }
    
        ...
    }
    //added class to perform the index to translate conversion
    public class MarkerPositionConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //calculated the transform values based on the following
            double itemIndex = (double)values[0];
            double trackHeight = (double)values[1];
            double translateDelta = trackHeight / MyClass.Instance.ItemCount;
            return itemIndex * translateDelta;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
