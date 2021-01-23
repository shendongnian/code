    using System.Windows;
    using System.Windows.Media;
    public partial class TetraHedron : Window
    {
        public TetraHedron()
        {
            InitializeComponent();
            DataContext = new PointCollection
                {
                    new Point(10, 20),
                    new Point(50, 30),
                    new Point(70, 90),
                    new Point(20, 54)
                };
        }
    }
