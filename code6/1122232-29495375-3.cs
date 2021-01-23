        using System.ComponentModel;
        public class MainWindow: INotifyPropertyChanged
        { 
            string[] defaultParam = { "A", "B", "C", "D" };
            private string _selecteditem_cob1;
            private string _selecteditem_cob2;
            private string _selecteditem_cob3;
            public List<string> DefaultList
            {
                get { return defaultParam.ToList(); }
            }
            public string SelectedItem_Cob1
            {
                get { return _selecteditem_cob1; }
                set
                {
                    if (_selecteditem_cob1 != value)
                    {
                        _selecteditem_cob1 = value;
                        RaisePropertyChanged("SelectedItem_Cob1");
                        RaisePropertyChanged("FilteredListA");
                        RaisePropertyChanged("FilteredListB");
                    }
                }
            }
            public string SelectedItem_Cob2
            {
                get { return _selecteditem_cob2; }
                set
                {
                    if (_selecteditem_cob2 != value)
                    {
                        _selecteditem_cob2 = value;
                        RaisePropertyChanged("SelectedItem_Cob2");
                        RaisePropertyChanged("FilteredListB");
                    }
                }
            }
            public string SelectedItem_Cob3
            {
                get { return _selecteditem_cob3; }
                set
                {
                    if (_selecteditem_cob3 != value)
                    {
                        _selecteditem_cob3 = value;
                        RaisePropertyChanged("SelectedItem_Cob3");
                    }
                }
            }
            public List<string> FilteredListA
            {
                get { return defaultParam.ToList().Where(a=>a!=SelectedItem_Cob1).ToList(); }
            }
            public List<string> FilteredListB
            {
                get { return FilteredListA.Where(a => a != SelectedItem_Cob2).ToList(); }
            }
            public MainWindow()
            {
    
                InitializeComponent();            
            }
         
            //Implementation for INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            protected void RaisePropertyChanged(String propertyName)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
