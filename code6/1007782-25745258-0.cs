     <Canvas Background="CadetBlue" Width="{Binding ElementName=Image1, Path=Width, Converter={StaticResource HeightConverter}}"
            Height="{Binding ElementName=Image1, Path=Height, Converter={StaticResource HeightConverter}}">
        <Image Name="Image1" Source="1.jpg" Width="150" Height="150" Stretch="Fill"/>
    </Canvas>
     [ValueConversion(typeof(double), typeof(double))]
    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result;
            Double.TryParse(value.ToString(), out result);
            return result + 20.0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
