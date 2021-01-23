    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string str = File.ReadAllText("1.txt");
            RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(str);
            dgr.ItemsSource = deserializedObject.response.ResultSet;
        }
    }
    public class ResultSet
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double ComputedProjectProgressAll { get; set; }
        public double ComputedProjectProgressCurrent { get; set; }
        public double ComputedProjectProgressExpected { get; set; }
        public int ComputedTaskCountAll { get; set; }
        public int ComputedTaskCountCurrent { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
    public class Response
    {
        public int Page { get; set; }
        public int PageFirst { get; set; }
        public int PageLast { get; set; }
        public int PageRecordFirst { get; set; }
        public long PageRecordLast { get; set; }
        public long PageSize { get; set; }
        public int RecordCount { get; set; }
        public List<ResultSet> ResultSet { get; set; }
    }
    public class RootObject
    {
        public string success { get; set; }
        public Response response { get; set; }
    }
     <Grid>
        <DataGrid x:Name="dgr"/>
    </Grid>
 
