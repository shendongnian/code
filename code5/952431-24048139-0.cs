    public partial class MainWindow : Window
        {
            public List<int> ListBoxData { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                ListBoxData = new List<int>() { 1, 2, 3, 4, 5, 6 };
                DataContext = this;
            }
        }
    
        public class NumberToColorConverter : IValueConverter
        {
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int number = (int)value;
                if (number % 2 == 0)
                {
                    return Brushes.LightBlue;
                }
                return Brushes.LightGreen;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    <Window x:Class="WpfApplication3.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication3"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <ListBox ItemsSource="{Binding ListBoxData}">
                <ListBox.Resources>
                    <local:NumberToColorConverter x:Key="NumberToColorConverter"/>
                    <Style TargetType="ListBoxItem">
                        <Setter Property="Background" Value="{Binding Converter={StaticResource NumberToColorConverter}}"/>
                    </Style>
                </ListBox.Resources>
            </ListBox>
        </Grid>
    </Window>
