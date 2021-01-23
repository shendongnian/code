    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var b = new Building();
            b.Name = "My Building";
    		
    		myClass.MyBuilding = b;
        }
    }
    
    class MyClass
    {
    	public Building MyBuilding {get; set;}
    }
