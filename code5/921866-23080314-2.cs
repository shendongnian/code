XAML
    <Window x:Class="MyNamespace.MainWindow"
            ...
            Loaded="Window_Loaded">
        <ListBox Name="MyListBox" ... />
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
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding(".")); // Here
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);
            var template = new DataTemplate();            
            template.VisualTree = textBlockFactory;
            MyListBox.ItemTemplate = template;
        }
    }
