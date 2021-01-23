     public ObservableCollection<ClassMM> topp { get; set; }
    
            private int dv, startindex, lastindex;
    
            public MainWindow()
            {
    
                InitializeComponent();
                DataContext = this;
                topp = new ObservableCollection<ClassMM>();
                startindex = dv = 1;
                topp.Add(new ClassMM() {PKId = dv, Name = "Test 1"});
                dv = 2;
                topp.Add(new ClassMM() {PKId = dv, Name = "Test 2"});
                dv = 3;
                topp.Add(new ClassMM() {PKId = dv, Name = "Test 3"});
    
                dv = 4;
                topp.Add(new ClassMM() {PKId = dv, Name = "Test 4"});
    
                lastindex = dv = 5;
                topp.Add(new ClassMM() {PKId = dv, Name = "Test 5"});
    
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                lastindex = dv = dv++;
    
                topp.Add(new ClassMM() { PKId = dv, Name = musavebutton.Content.ToString() });
                foreach (var jk in topp.ToList())
                {
                    MessageBox.Show(jk.Name);
                }
            }
    
            public class ClassMM : INotifyPropertyChanged
            {
                public string _name;
                public int _pkid;
    
    
                public int PKId
                {
                    get { return _pkid; }
                    set
                    {
                        if (value != _pkid)
                        {
                            _pkid = value;
                            NotifyPropertyChanged("PKId");
                        }
                    }
                }
    
    
    
                public string Name
                {
                    get { return _name; }
                    set
                    {
                        if (value != _name)
                        {
                            _name = value;
                            NotifyPropertyChanged("Name");
                        }
                    }
                }
    
    
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected void NotifyPropertyChanged(String propertyName)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
            }
