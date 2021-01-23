    public static class MyExtensions
    {
        public static Size GetSize(this Windows.UI.Xaml.Shapes.Rectangle rectangle)
        {
            return rectangle.RenderSize;
        }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Rectangle rectangle = new Rectangle();
            Debug.WriteLine(rectangle.GetSize());
        }
    }
