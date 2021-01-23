    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            IWorkSpaceViewControl control = tabControl.SelectedContent as IWorkSpaceViewControl;
            control.Refresh();
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tabControl != null)
            {
                e.CanExecute = ((IWorkSpaceViewControl)tabControl.SelectedContent).CanSave;
            }
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((IWorkSpaceViewControl)tabControl.SelectedContent).Save();
        }
    }
