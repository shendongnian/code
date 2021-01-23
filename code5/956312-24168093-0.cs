    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
           public static readonly DependencyProperty FrontTextProperty = DependencyProperty.Register( "FrontText", typeof(string),typeof(UserControl1), new FrameworkPropertyMetadata(string.Empty));
        public string FrontText
        {
            get { return (string)GetValue(FrontTextProperty); }
            set {
                SetValue(FrontTextProperty, value);
                frontBlock.Text = value;  
            }
            
        }
        public static readonly DependencyProperty EllipseStateProperty = DependencyProperty.Register("EllipseState", typeof(bool), typeof(UserControl1), new FrameworkPropertyMetadata(false));
        public bool EllipseState
        {
            get { return (bool)GetValue(EllipseStateProperty); }
            set
            {
                SetValue(EllipseStateProperty, value);
                if (value)
                {
                    ellipse.Fill  = new SolidColorBrush( Colors.Green);  
                }
                else
                {
                    ellipse.Fill = new SolidColorBrush(Colors.Red);
                }
               
            }
        }
	
     
    }
