    DataSet set; // set is a field of the class, rather than a local variable
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable table1 = new DataTable();
        ** Lines removed **
        this.set = new DataSet(); // set should be an instance variable
        set.Tables.Add(table1);
        set.Tables.Add(table2);
        ** Lines removed **
    }
    protected void Button1Click(object sender, EventArgs args)
    {
        DataSet ds = this.set;
        createExcel(ds);
    }
