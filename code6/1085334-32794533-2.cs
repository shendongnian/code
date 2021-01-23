        public NavigationImage()
        {
            InitializeComponent();
            DataContext = this;
            _zoom = 1.0;
        }
        double _zoom;
        public string ZoomPercentage
        {
            get
            {
                return _zoom * 100 + "%";
            }
        }
        private void scrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                _zoom += 0.1;
            }
            else
            {
                _zoom -= 0.1;
            }
            ScaleTransform scale = new ScaleTransform(_zoom, _zoom);
            navigationImage.LayoutTransform = scale;
            OnPropertyChanged("ZoomPercentage");
            e.Handled = true;
        }
