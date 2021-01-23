    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MyViewModel1), typeof(UserControl1));
        public UserControl1()
        {
            InitializeComponent();
        }
        public MyViewModel1 ViewModel
        {
            get { return GetValue(ViewModelProperty) as MyViewModel1; }
            set { SetValue(ViewModelProperty, value); }
        }
    }
