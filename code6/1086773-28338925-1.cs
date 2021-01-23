    public partial class SimpleGraph : ItemsControl
    {
        public Geometry DataPointGeometry
        {
            get { return (Geometry)GetValue(DataPointShapeProperty); }
            set { SetValue(DataPointShapeProperty, value); }
        }
        public static DependencyProperty DataPointShapeProperty = DependencyProperty.Register(
            "DataPointGeometry", typeof(Geometry), typeof(SimpleGraph));
        public SimpleGraph()
        {
            InitializeComponent();
            DataPointGeometry = (Geometry)FindResource("defaultGraphGeometry");
        }
    }
