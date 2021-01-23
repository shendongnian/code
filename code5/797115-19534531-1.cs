       public partial class MainWindow : Window
    {
        public DataTable CmbxData { get; set; }
        public IList<string> Test { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CmbxData = new DataTable();
            CmbxData.Columns.Add("Column1", typeof(int));
            CmbxData.Columns.Add("Column2", typeof(String));
            CmbxData.Rows.Add(new object[] { 1, "Value1" });
            CmbxData.Rows.Add(new object[] { 2, "Value2" });
            CmbxData.Rows.Add(new object[] { 3, "Value3" });
            this.Test = new List<string>();
            this.Test.Add("Test 1");
            this.dataGridTest.ItemsSource = this.Test;
          
        }
    }
