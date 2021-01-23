    public partial class ViewModelControl : Window, IViewModelControl
    {
        public ViewModelControl()
        {
            InitializeComponent();
            this.DataContext = new ViewModel1();
        }
        public virtual void bindFirstDataContext()
        {
        }
        public virtual void bindSecondDataContext()
        {
        }
    }
