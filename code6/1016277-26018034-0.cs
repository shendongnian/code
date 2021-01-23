    // without DependencyProperty
    public class Graph : FrameworkElement
    {
        // Figures
        public List<Figure> Figures { get; set; }
        public Graph()
        {
            Figures = new List<Figure>();
        }
    }
    // with DependencyProperty
    public class Graph : FrameworkElement
    {
        // Figures
        private static readonly DependencyPropertyKey FiguresPropertyKey = DependencyProperty.RegisterReadOnly("Figures", typeof(ObservableCollection<Figure>), typeof(Graph), new FrameworkPropertyMetadata(new ObservableCollection<Figure>()));
        public static readonly DependencyProperty FiguresProperty = FiguresPropertyKey.DependencyProperty;
        public ObservableCollection<Figure> Figures { get { return (ObservableCollection<Figure>)GetValue(FiguresProperty); } }
        public Graph()
        {
            // explanation for this, see http://msdn.microsoft.com/en-us/library/aa970563%28v=vs.110%29.aspx
            SetValue(FiguresPropertyKey, new ObservableCollection<Figure>());
        }
    }
