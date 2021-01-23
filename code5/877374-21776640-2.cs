        public ParentUserControl(System.Drawing.Color c)
        {
            InitializeComponent();
            Color c2 = Color.FromRgb(c.R, c.G, c.B);
            ChildForeColor = c2;
            
        }
        private Color _ChildForeColor = Color.FromRgb(0, 255, 0);
        public Color ChildForeColor
        {
            get { return _ChildForeColor; }
            set
            {
                if (value != _ChildForeColor)
                {
                    _ChildForeColor = value;
                    OnPropertyChanged(() => ChildForeColor);
                }
            }
        }
