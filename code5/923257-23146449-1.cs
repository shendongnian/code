    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Xaml.Shapes;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    
    namespace StoreApp_PolyTest
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
            }
    
            private void Canvas_Loaded(object sender, RoutedEventArgs e)
            {
                Polygon MyPolygon = new Polygon();
                MyPolygon.Points.Add(new Point(0, 0));
                MyPolygon.Points.Add(new Point(95, 0));
                MyPolygon.Points.Add(new Point(95, 35));
                MyPolygon.Points.Add(new Point(10, 35));
                MyPolygon.Points.Add(new Point(0, 75)); // 
    
                MyPolygon.Stroke = new SolidColorBrush(Colors.Blue);
                MyPolygon.Fill = new SolidColorBrush(Colors.Blue);
    
                canvas.Children.Add(MyPolygon);
    
                MyPolygon.PointerPressed += MyPolygon_PointerPressed;
            }
    
            void MyPolygon_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                TextBlock nameText = new TextBlock() {Text="1234"};
                var point = e.GetCurrentPoint(this);
                Canvas.SetLeft(nameText, point.Position.X);
                Canvas.SetTop(nameText, point.Position.Y);
                canvas.Children.Add(nameText);
            }
        }
    }
