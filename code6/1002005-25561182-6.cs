     public class Test
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public partial class MainWindow : Window
    {
        private List<Test> lst;
        public List<Test> LST
        {
            get { return lst; }
            set { lst = value; }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LST = new List<Test>();
            for (int i = 0; i < 10; i++)
            {
                Test t = new Test();
                t.ID = i;
                t.Name = i + "name";
                LST.Add(t);
            }
  
        }
    }
