    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewKeyDown(e);
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewMouseDown(e);
        }
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewMouseMove(e);
        }
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewMouseWheel(e);
        }
        protected override void OnPreviewTouchDown(TouchEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewTouchDown(e);
        }
        protected override void OnPreviewTouchMove(TouchEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewTouchMove(e);
        }
    }
