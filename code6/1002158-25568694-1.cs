    //using the global variable
    Second_DDL.DataSource = dtSubCategories;
    //using a property
    Second_DDL.DataSource = DTSubCategories;
    public DataTable DTSubCategories
    {
        get { return dtSubCategories; }
        set { dtSubCategories = value; }
    }
    //using a method
    Second_DDL.DataSource = GetSubCategories();
    private DataTable GetSubCategories()
    {
        return dtSubCategories;
    }
