    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var storyboard = new Storyboard();
            var pointAnimation = new DoubleAnimation()
            {
                From = Canvas.GetLeft(Button),
                To = Canvas.GetLeft(Button) + 200,
                Duration = new Duration(TimeSpan.FromSeconds(10))
            };
            Storyboard.SetTarget(pointAnimation, Button);
            Storyboard.SetTargetProperty(pointAnimation, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(pointAnimation);
            storyboard.Begin();
        }
