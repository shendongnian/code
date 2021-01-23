    protected void Page_Load(object sender, EventArgs e)
    {
    	if(!IsPostBack)
    	{
    	    List<Customer> customerList = new List<Customer>();
    	    customerList.Add(new Customer{ CustomerID = 1, CustomerName = "1654184185"});
    	    customerList.Add(new Customer { CustomerID = 2, CustomerName = "sdfsdfsdfs" });
    	    customerList.Add(new Customer { CustomerID = 3, CustomerName = "dsdfsrtertertdf" });
    
    	    ReportViewer1.LocalReport.ReportPath = "Report.rdlc";
    	    ReportDataSource rds = new ReportDataSource("DataSet1_Customers_DataTable1", customerList);
    	    ReportViewer1.LocalReport.DataSources.Clear();
    	    ReportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
