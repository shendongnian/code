    public DataTable MyData { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.DataSource =MyData  ;
        DropDownList1.DataBind();
    }
    
    public void SetData(DataSet dTLookupValues)
    {
        MyData  = dTLookupValues.Tables[0];
    }
