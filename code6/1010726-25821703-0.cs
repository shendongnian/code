    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (lstEmployees.Count > 0)
        {
          lstEmployees.First().FirstName = "Test";
          rptEmployees.DataSource = lstEmployees;
         //You need to rebind the repeater
          rptEmployees.DataBind();
        }
    }
    
    private List<Employee> lstEmployees = new List<Employee>();
