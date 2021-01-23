    class CircleObject
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public double Thickness { get; set; }
        public Thickness Margin {
            get { 
                return new Thickness(Left, Top, 0, 0);
            }
        }
        public Brush Fill { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<CircleObject> circles;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            SolidColorBrush b = new SolidColorBrush(Colors.White);
            circles = new ObservableCollection<CircleObject>();
            circles.Add(new CircleObject() { Left = 40, Top = 300, Thickness = 10, Fill = b });
            circles.Add(new CircleObject() { Left = 80, Top = 250, Thickness = 20, Fill = b });
            circles.Add(new CircleObject() { Left = 120, Top = 240, Thickness = 30, Fill = b });
            circles.Add(new CircleObject() { Left = 160, Top = 275, Thickness = 20, Fill = b });
            circles.Add(new CircleObject() { Left = 200, Top = 275, Thickness = 30, Fill = b });
            circles.Add(new CircleObject() { Left = 240, Top = 130, Thickness = 40, Fill = b });
            circles.Add(new CircleObject() { Left = 280, Top = 150, Thickness = 50, Fill = b });
            circles.Add(new CircleObject() { Left = 320, Top = 200, Thickness = 40, Fill = b });
            circles.Add(new CircleObject() { Left = 360, Top = 220, Thickness = 30, Fill = b });
            
            ic.ItemsSource = circles;
        }
