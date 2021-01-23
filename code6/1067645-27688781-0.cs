    public partial class BusyIndicator : UserControl
    {
        public BusyIndicator()
        {
            InitializeComponent();
        }
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }
        public static readonly DependencyProperty IsBusyProperty =  
        DependencyProperty.Register("IsBusy", typeof(bool), typeof(BusyIndicator), 
        new PropertyMetadata(false));
    }
