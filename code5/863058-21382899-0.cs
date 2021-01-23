    public partial class PeopleChooser : UserControl
    {
        public PeopleChooser()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty AllowMultipleProperty = DependencyProperty.Register("AllowMultiple", typeof(bool), typeof(PeopleChooser), null);
        public bool AllowMultiple
        {
            get { return (bool)GetValue(AllowMultipleProperty); }
            set { SetValue(AllowMultipleProperty, value); }
        }
    }
    <UserControl x:Class="TestSilverlightApplication.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DesignHeight="300" d:DesignWidth="400"
        xmlns:lcl="clr-namespace:TestSilverlightApplication">
        <UserControl.Resources>
            <lcl:VisibilityConverter x:Key="VisibilityConverter" />
        </UserControl.Resources>
        <Grid x:Name="LayoutRoot" Background="White">
            <StackPanel Orientation="Vertical">
                <Button Click="Button_Click" Content="Toggle allow multiple" />
                <lcl:PeopleChooser x:Name="lclPeopleChooser" AllowMultiple="False"></lcl:PeopleChooser>
                <TextBlock Text="Dependent content" Visibility="{Binding AllowMultiple, ElementName=lclPeopleChooser, Converter={StaticResource VisibilityConverter}}" />
            </StackPanel>
        </Grid>
    </UserControl>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lclPeopleChooser.AllowMultiple = !lclPeopleChooser.AllowMultiple;
        }
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool parsedValue = false;
            bool.TryParse(value.ToString(), out parsedValue);
            if (parsedValue)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
