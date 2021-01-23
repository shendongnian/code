       public partial class test : Form
       {
        DataTable dtSource = new DataTable();
        int takecount = 50;
        int skipcount = 0;
        DataTable dtResult;
        // CONSTRUCTOR
        public test()
        {
            InitializeComponent();
            
            // Fill Dummy data here as datasource...
            dtSource.Columns.Add("SNo", typeof(int));
            dtSource.Columns.Add("Name", typeof(string));
            dtSource.Columns.Add("Address", typeof(string));
            int i = 1;
            while (i <= 500)
            {               
                dtSource.Rows.Add(new object[] { i, "Name: " + i, "Address " + i });
                i++;
            }
            dtResult = dtSource.Copy();
            dtResult.Clear();
        }
        // ON FORM LOAD FUNCTION CALL
        private void test_Load(object sender, EventArgs e)
        {            
            ultraGrid1.DataSource = dt_takeCount();
            ultraGrid1.DataBind();
           
            
        }
        private DataTable dt_takeCount()
        {            
            if (dtSource.Rows.Count - skipcount <= takecount)
            {
                takecount = dtSource.Rows.Count - skipcount;
            }
            foreach (var item in dtSource.AsEnumerable().Skip(skipcount).Take(takecount))
            {
                dtResult.Rows.Add(new object[] { item.Field<int>("SNo"), item.Field<string>("Name"), item.Field<string>("Address") });
            }
            if (dtSource.Rows.Count - skipcount >= takecount)
            {
                skipcount += takecount;               
            }            
            return dtResult;
        }
        // EVENT FIRED WHEN ON AFTERROWREGIONSCROLL
        private void ultraGrid1_AfterRowRegionScroll(object sender, Infragistics.Win.UltraWinGrid.RowScrollRegionEventArgs e)
        {
            int _pos = e.RowScrollRegion.ScrollPosition;
            if (ultraGrid1.Rows.Count - _pos < takecount)
            {
                dt_takeCount();
            }           
        }        
    }
