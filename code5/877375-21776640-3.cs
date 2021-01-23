        public Control ParContent
        {
            get { return (ContentControl)GetValue(ParContentProperty); }
            set { SetValue(ParContentProperty, value); }
        }
        //Register Dependency ParContent Property
        public static readonly DependencyProperty ParContentProperty = DependencyProperty.Register("ParContent", typeof(ContentControl), typeof(MainWindow), new PropertyMetadata( ));
        public MainWindow()
        {
           InitializeComponent();  
           ParContent = new ParentUserControl(System.Drawing.Color.Blue);
        }
