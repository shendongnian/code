    private DataTable dt = null;
    
    private void CreateTable() 
    {
        dt = new DataTable();
    
        dt.Columns.Add(new System.Data.DataColumn("SrNo", typeof(int)));
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("address", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("ContactNo", typeof(int)));
        dt.Columns.Add(new System.Data.DataColumn("amount", typeof(double)));
        dt.Columns.Add(new System.Data.DataColumn("Emailid", typeof(string)));
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        CreateTable();
    }
