    public partial class AntecedentControl : UserControl
    {
        public static readonly DependencyProperty AntecedentListProperty = DependencyProperty.Register("AntecedentList", typeof(ObservableCollection<Antecedent>), typeof(AntecedentControl));
        public ObservableCollection<Antecedent> AntecedentList
        {
            get { return (ObservableCollection<Antecedent>)GetValue(AntecedentListProperty); }
            set { SetValue(AntecedentListProperty, value); }
        }
        public AntecedentControl()
        {
            InitializeComponent();
        }
    }
