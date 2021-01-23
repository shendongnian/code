    public static readonly new DependencyProperty GControlProperty =
        DependencyProperty.Register("GLControl", typeof(OpenGLControl), typeof(FancyOpenGlControl), new PropertyMetadata(null));
    public OpenGLControl GLControl
    {
        get { return (OpenGLControl )GetValue(DocumentProperty); }
        set { SetValue(GLControlProperty , value); }
    }
    public FancyOpenGlControl()
    {
        this.InitializeComponent();
        this.GLControl= new OpenGLControl();
        this.GLControl.Dock = DockStyle.Fill;
        this.WindowsFormsHost.Child = this.GLControl;
    }
