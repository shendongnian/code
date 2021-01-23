    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeWebService obj = new EmployeeWebService ();
        ArrayList list = obj.GetValues();//Calling webmethod
        foreach (object o in list)
            Response.Write(o.Name + " ");
    }
