    <Window x:Class="MultiLangConverterHelp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"        
            xmlns:local="clr-namespace:MultiLangConverterHelp"
            WindowStartupLocation="CenterScreen"
            Title="MainWindow" Height="350" Width="525">
    
        <Window.Resources>
            <local:StaticResourceConverter x:Key="converter" />
            <local:TestViewModel x:Key="viewModel" />
        </Window.Resources>
    
        <Grid DataContext="{StaticResource viewModel}">
            <TextBlock Text="{Binding Path=CurrentCulture, Converter={StaticResource converter}}" />
        </Grid>
    </Window>
MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class StaticResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentCulture = (string)value;
            if (currentCulture.Equals("EN-en")) 
            {
                return Application.Current.Resources["HelloStringEN"];
            }
            else if (currentCulture.Equals("RU-ru"))
            {
                return Application.Current.Resources["HelloStringRU"];
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class TestViewModel : NotificationObject
    {
        private string _currentCulture = "EN-en";
        public string CurrentCulture
        {
            get
            {
                return _currentCulture;
            }
            set
            {
                _currentCulture = value;
                NotifyPropertyChanged("CurrentCulture");
            }
        }
    }
