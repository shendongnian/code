	private string test = WebConfigurationManager.ConnectionStrings["Test"].ConnectionString; //returns "ExecuteTest" -- note! no parenthesis!
    
    protected void Page_Load(object sender, EventArgs e)
    {
        MethodInfo m = this.GetType().GetMethod(test); //expects static method
        if (m != null)
        {
            object result = m.Invoke(this, new object[] { });
        }
    }
    private static void ExecuteTest()
    {
        //do stuff
    }
