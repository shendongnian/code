     public UserControl1()
        {
            InitializeComponent();
        }
        bool showLoadButton;
        public bool ShowLoadButton
        {
            get { return showLoadButton; }
            set
            {
                showLoadButton = value;
                if (showLoadButton)
                    Loadbutton.Visibility = Visibility.Visible;
                else
                    Loadbutton.Visibility = Visibility.Collapsed;
            }
        }
