    <!-- MyString is your Property, MyConverter is your Converter you programmed, ConverterParamter is the row_number that you want to pass to MyConver -->
    <TextBlock x:Name="tb">
        <Run FontSize="12" Text="{Binding MyString, Converter={StaticResource MyConverter}, ConverterParameter=0}"/>
        <Run FontSize="24" Text="{Binding MyString, Converter={StaticResource MyConverter}, ConverterParameter=1}"/>                
    </TextBlock>
----------
    // sample Converter of what you want to do
    using System.Windows.Data;
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string return_string = "";
            int rowid = (int) parameter;
            switch (rowid)
            {
                case 0:
                    return_string = "sub_string_row_0"; // calculate the substring for row 0
                    break;
                case 1:
                    return_string = "sub_string_row_1"; // calculate the substring for row 1
                    break;
                default:
                    break;
            }    
            return return_string;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
