      public partial class MainWindow : Window, INotifyPropertyChanged
      {
       private ObservableCollection<FieldSample>_fieldAnalysis;
       public ObservableCollection<FieldSample> fieldAnalysis
       {
        get{return _fieldAnalysis;}
        set{
            _fieldAnalysis=value;
            PropertyChanged(this,new PropertyChangedEventArgs("fieldAnalysis"));
           }
       }
       public event PropertyChangedEventHandler  PropertyChanged;
        
    public MainWindow()
    {
        InitializeComponent();
        fieldAnalysis = new ObservableCollection<FieldSample>();
        this.DataContext = this;
    }
