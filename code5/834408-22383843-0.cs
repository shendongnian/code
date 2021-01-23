        public MainForm : Form
        {
            readonly GLControl glControl = new GLControl();
            public MainForm()
            {
                InitializeComponent();
                glControl.CreateControl(); // Force the GLControl to be created
            }
            // ...
        }
        
