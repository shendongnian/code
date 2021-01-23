    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    		List<Raw> RawData = new List<Raw>() 
    		{
    			new Raw(){SearchData = "Jimmy", ID="001"},
    			new Raw(){SearchData = "Jack", ID="002"},
    			new Raw(){SearchData = "Jim", ID="003"},
    			new Raw(){SearchData = "Jerry", ID="004"},
    			new Raw(){SearchData = "Jason", ID="005"},
    			new Raw(){SearchData = "Jeff", ID="006"},
    		};
    		this.Combo.ItemsSource = RawData;
    	}
    }
    
    public class Raw
    {
    	public string SearchData { get; set; }
    	public string ID { get; set; }
    }
