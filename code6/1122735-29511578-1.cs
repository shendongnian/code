     public partial class MainWindow : Window
    {
        public ObservableCollection<Item> DataGridItems { get; set; }   
        public MainWindow()
        {
            InitializeComponent();
            DataGridItems=new ObservableCollection<Item>()
            {
                new Item()
                {
                    Clm1 = "Item1"
                }, new Item()
                {
                    Clm1 = "Item2"
                }, new Item()
                {
                    Clm1 = "Item3"
                }
            };
            Dg.ItemsSource = DataGridItems.Select((item) =>
            
                new
                {
                    Clm1 = item.Clm1,
                    Clm2= "Item2",
                    Clm3=true
                }
            );
        }
    }
    public class Item
    {
        public String Clm1 { get; set; }      
    }
