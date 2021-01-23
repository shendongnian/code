    public partial class ChildWindow : Window, IPopupDialogWindow
    {
        public ChildWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public new PopupDialogResult DialogResult
        {
            get;
            set;
        }
        public System.Windows.Input.ICommand DialogResultCommand
        {
            get;
            set;
        }
    }
