    protected void Page_Load(object sender, EventArgs e)
        {
            myDataTable = new DataTable();
            //....
            HttpContext.Current.Session["name"] = myDataTable;    //overriding to the previous
