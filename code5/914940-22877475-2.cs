    public ICommand TestCommand
    {
     get
        {
            if(_testCommand == null)
            {
                _testCommand = new RelayCommand(OnTestCommand); //ICommand implementation
             }
             return _testCommand;
         }
    }
    
    public void OnTestCommand(object args)
    {
        var array = (object[])args;
        var p1 = array[0];
        var p2 = array[1];
    }
    
        public class MultiValueConverter : IMultiValueConverter
        {
    
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                //Important. Otherwise values in execute method of command will be null.
                return values.ToArray();
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
