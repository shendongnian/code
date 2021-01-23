    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MyViewModel), typeof(UserControl1));
    
        public UserControl1()
        {
            InitializeComponent();
        }
    
        public MyViewModel ViewModel
        {
            get { return GetValue(ViewModelProperty) as MyViewModel; }
            set { SetValue(ViewModelProperty, value); }
        }
    }
