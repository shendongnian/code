     public partial class MainPage  : PhoneApplicationPage, INotifyPropertyChanged
        {
            PhoneNumberChooserTask phNumChoseTask;
            private String _tb1;
    
            public String tb1
            {
                get { return _tb1; }
                set { _tb1 = value; OnPropertyChanged("tb1"); }
            }
    
            private String _tb2;
    
            public String tb2
            {
                get { return _tb2; }
                set { _tb2 = value; OnPropertyChanged("tb2"); }
            }
    
            private Button _ClickedBut;
    
            public Button ClickedBut
            {
                get { return _ClickedBut; }
                set { _ClickedBut = value; }
            }
    
    
            public MainPage()
            {
                this.DataContext = this;
                InitializeComponent();
                phNumChoseTask = new PhoneNumberChooserTask();
                phNumChoseTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ClickedBut = (sender as Button);
                phNumchoseTask.Show();
            }
            void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
            {
                if (e.TaskResult == TaskResult.OK)
                {
                    if (ClickedBut.Tag == "1")
                        tb1 = e.PhoneNumber;
                    else if (ClickedBut.Tag == "2")
                        tb2 = e.PhoneNumber;
                }
            }
            void OnPropertyChanged(String prop)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
    
        }
