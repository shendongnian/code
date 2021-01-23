    namespace WpfApplication2
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tuple<string,string>> observableCollection = new ObservableCollection<Tuple<string,string>>();  
        public MainWindow()
        {
            InitializeComponent();            
            for (int i = 0; i < 100; i++)
            {
                observableCollection.Add( Tuple.Create("item " + i.ToString(),"=sum (c5+c4)"));
            }
            dg1.ItemsSource = observableCollection; 
             
            dg1.CurrentCellChanged += dg1_CurrentCellChanged;
            
        }
        void dg1_CurrentCellChanged(object sender, EventArgs e)
        {
            //int rowIndex = dg1.SelectedIndex;   
            Tuple<string, string> tuple = dg1.CurrentItem as Tuple<string, string>; 
            //here as you have your datacontext you can loop through and calculate what you want 
        }
    }
    }
