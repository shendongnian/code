XAML
    <Window x:Class="CreateAnimationinCodeHelp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Name="MyWindow"
            Title="MainWindow" Height="350" Width="525"
            Loaded="Window_Loaded">
        <Grid>
            <Label Background="AliceBlue" Content="Test" />
        </Grid>
    </Window>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 200;
            doubleAnimation.To = 500;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            doubleAnimation.AccelerationRatio = 0.1;
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.Top)"));
            sb.Children.Add(doubleAnimation);
            
            MyWindow.BeginStoryboard(sb);
        }
    }
