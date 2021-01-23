      public partial class MainWindow : Window
    {                         
        public MainWindow()
        {
            InitializeComponent();
            List<Meassage> RequestList = new List<Meassage>();
         
            RequestList.Add(new Meassage()
            {
                Reaquest = "request",
                Models = new List<Commands>(){new Commands(){ Name = "command", SameName="command"},
                                              new Commands(){Name = "Metainfo", SameName="MetaInfo"},
                                              new Commands(){Name = "data", SameName="result" },}
            });
                
            RequestList.Add(new Meassage()
            {
                Reaquest = "response",
                Models = new List<Commands>(){new Commands(){ Name = "command", SameName="command"},
                                              new Commands(){Name = "Metainfo", SameName="MetaInfo"},
                                              new Commands(){Name = "data", SameName="result" },}
            });
                         
            lst.ItemsSource = RequestList;
        }
        private void UniformGrid1_Loaded_1(object sender, RoutedEventArgs e)
        {
            UniformGrid un = sender as UniformGrid;          
            var ab= un.ActualHeight;
            var ItemsCount = un.Children.Count;
            var SingleHeight = ab/ItemsCount;
            BorderWidth.Height = SingleHeight * (ItemsCount - 1);
        }    
    }
    public class Meassage
    {
        public string Reaquest { get; set; }
 
        public List<Commands> Models { get; set; }
    }
    public class Commands
    {
        public string Name { get; set; }
        public string SameName{ get; set; }
       
    }
