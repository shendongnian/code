    public MainWindow()
            {
                InitializeComponent();
                SharpGL.WPF.OpenGLControl op = new SharpGL.WPF.OpenGLControl();
                SharpGL.OpenGL gl = op.OpenGL;
                SharpGLControlPanel.Children.Add(op);
            }
