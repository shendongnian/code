       public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MyControls = new ObservableCollection<MyControl>();
            var a = new MyControl { MyLabelContent = "label content 1", MyTextBlockContent = "Text content 1" };
            var b = new MyControl { MyLabelContent = "label content 2", MyTextBlockContent = "Text content 2" };
            MyControls.Add(a);
            MyControls.Add(b);
        }
        private void MyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null)
            {
                var selectedItem = listBox.SelectedItems[0] as MyControl;
                var textBlockContent = selectedItem.MyTextBlockContent;
                var labelContent = selectedItem.MyLabelContent;
            }
        }
        private ObservableCollection<MyControl> _myControls;
        public ObservableCollection<MyControl> MyControls
        {
            get { return _myControls; }
            set
            {
                _myControls = value;
                NotifyPropertyChanged("MyControls");
            }
        }
        #region PropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
