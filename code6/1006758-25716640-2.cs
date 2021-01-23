    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace NSR3
    {
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        UCDragme box;
        public Home()
        {
            InitializeComponent();
            box = new UCDragme();
            TextBlock tb = (TextBlock)box.FindName("TBDragme");
            tb.MouseLeftButtonDown += box_MouseLeftButtonDown;
            tb.MouseLeftButtonUp += box_MouseLeftButtonUp;
            tb.MouseMove += box_MouseMove;
            panel.Children.Add(box);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            box = new UCDragme();
            TextBlock tb=(TextBlock)box.FindName("TBDragme");
            tb.MouseLeftButtonDown += box_MouseLeftButtonDown;
            tb.MouseLeftButtonUp += box_MouseLeftButtonUp;
            tb.MouseMove += box_MouseMove;
            panel.Children.Add(box);
        }
        private TextBlock draggedBox;
        private Point clickPosition;
        private void box_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            draggedBox = sender as TextBlock;
            clickPosition = e.GetPosition(draggedBox);
            draggedBox.CaptureMouse();
        }
        private void box_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            draggedBox.ReleaseMouseCapture();
            draggedBox = null;
            //box = null;
        }
        private void box_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedBox != null)
            {
                Point currentPosition = e.GetPosition(panel);
                box.RenderTransform = draggedBox.RenderTransform as TranslateTransform ?? new TranslateTransform();
                TranslateTransform transform = box.RenderTransform as TranslateTransform;
                transform.X = currentPosition.X - clickPosition.X - draggedBox.Margin.Left;
                transform.Y = currentPosition.Y - clickPosition.Y - draggedBox.Margin.Right;
            }
        }
    }
    }
