    private ObservableCollection<PaletteEntry> _paletteEntries = new  ObservableCollection<PaletteEntry>();
    public ObservableCollection<PaletteEntry> PaletteEntries
    {
        get { return _paletteEntries; }
        set { _paletteEntries = value; OnPropertyChanged("PaletteEntries"); }
    }
    public class PaletteEntry : INotifyPropertyChanged
        {
            private string _count;
            public string Count
            {
                get { return _count; }
                set
                {
                    _count = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Count"));
                }
            }
            private string _readOnly;
            public string ReadOnly
            {
                get { return _readOnly; }
                set
                {
                    _readOnly = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ReadOnly"));
                }
            }
            private string _displayPalletteType;
            public string DisplayPalletteType
            {
                get { return _displayPalletteType; }
                set
                {
                    _displayPalletteType = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("DisplayPalletteType"));
                }
            }
            private string _title;
            public string Title
            {
                get { return _title; }
                set
                {
                    _title = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
            private SolidColorBrush _background;
            public SolidColorBrush Background
            {
                get { return _background; }
                set
                {
                    _background = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Background"));
                }
            }
            private string _backname;
            public string BackName
            {
                get { return _backname; }
                set
                {
                    _backname = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("BackName"));
                }
            }
            private string _backR;
            public string BackR
            {
                get { return _backR; }
                set
                {
                    _backR = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("BackR"));
                }
            }
            private string _backG;
            public string BackG
            {
                get { return _backG; }
                set
                {
                    _backG = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("BackG"));
                }
            }
            private string _backB;
            public string BackB
            {
                get { return _backB; }
                set
                {
                    _backB = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("BackB"));
                }
            }
            private SolidColorBrush _foreground;
            public SolidColorBrush Foreground
            {
                get { return _foreground; }
                set
                {
                    _foreground = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Foreground"));
                }
            }
            private string _forename;
            public string ForeName
            {
                get { return _forename; }
                set
                {
                    _forename = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ForeName"));
                }
            }
            private string _foreR;
            public string ForeR
            {
                get { return _foreR; }
                set
                {
                    _foreR = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ForeR"));
                }
            }
            private string _foreG;
            public string ForeG
            {
                get { return _foreG; }
                set
                {
                    _foreG = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ForeG"));
                }
            }
            private string _foreB;
            public string ForeB
            {
                get { return _foreB; }
                set
                {
                    _foreB = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ForeB"));
                }
            }
            private string _tags;
            public string Tags
            {
                get { return _tags; }
                set
                {
                    _tags = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Tags"));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        };
