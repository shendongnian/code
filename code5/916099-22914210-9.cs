    public partial class UserControl1 : UserControl
    {
        #region Items
        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(
            "Items",
            typeof(IEnumerable<object>),
            typeof(UserControl1),
            new UIPropertyMetadata(null));
        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        #endregion
        #region Selected
        public static readonly DependencyProperty SelectedProperty =
        DependencyProperty.Register(
            "Selected",
            typeof(object),
            typeof(UserControl1),
            new UIPropertyMetadata(null));
        public object Selected
        {
            get { return (object)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        #endregion
        public UserControl1()
        {
            InitializeComponent();
        }
    }
