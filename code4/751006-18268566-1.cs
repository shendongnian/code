    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<DependencyObject> _hitResultsList = new List<DependencyObject>();
        private Point _currentlyDraggedMouseOffset;
        private Label _currentlyDragged;
        private ObservableCollection<string> _labelsCollection;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            LabelsCollection = new ObservableCollection<string>();
            for (int i = 1; i <= 10; i++)
            {
                LabelsCollection.Add("Label " + i);
            }
        }
        
        public ObservableCollection<string> LabelsCollection
        {
            get { return _labelsCollection; }
            set
            {
                _labelsCollection = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LabelsCollection"));
                }
            }
        }
        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_currentlyDragged != null)
            {                
                var mousePos = e.GetPosition(this);
                _currentlyDragged.RenderTransform = new TranslateTransform(mousePos.X - _currentlyDraggedMouseOffset.X, mousePos.Y - _currentlyDraggedMouseOffset.Y);
            }
        }
        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _currentlyDragged = null;
            ReleaseMouseCapture();
        }
        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CaptureMouse();
            Point pt = e.GetPosition((UIElement)sender);
            _hitResultsList.Clear();
            VisualTreeHelper.HitTest(this, null,
                new HitTestResultCallback(MyHitTestResult),
                new PointHitTestParameters(pt));
            if (_hitResultsList.Count > 0)
            {
                foreach (DependencyObject d in _hitResultsList)
                {
                    var parent = VisualTreeHelper.GetParent(d);
                    if (parent != null && parent is Label)
                    {
                        _currentlyDragged = parent as Label;
                        if (_currentlyDragged.RenderTransform is TranslateTransform)
                        {
                            _currentlyDraggedMouseOffset.X = e.GetPosition(this).X - ((TranslateTransform)_currentlyDragged.RenderTransform).X;
                            _currentlyDraggedMouseOffset.Y = e.GetPosition(this).Y - ((TranslateTransform)_currentlyDragged.RenderTransform).Y;
                        }
                        else
                        {
                            _currentlyDraggedMouseOffset.X = pt.X;
                            _currentlyDraggedMouseOffset.Y = pt.Y;
                        }
                        return;
                    }
                }
            }
            _currentlyDragged = null;
        }
        // Return the result of the hit test to the callback. 
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            _hitResultsList.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
        
    }
