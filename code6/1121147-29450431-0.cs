    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
         {
            FillDropDowns();
         }
    }
    protected void FillDropDowns()
    {
       int[] days = new int[31];
    
        for (int i = 0; i < days.Length; i++)
        {
            days[i] = i + 1;
        }
        //Binding the information to drop downlist.
        ddlDayCI.DataSource = days;
        ddlDayCI.DataBind();
        ddlDayCO.DataSource = days;
        ddlDayCO.DataBind();
    
        int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        ddlMonthCI.DataSource = months;
        ddlMonthCI.DataBind();
        ddlMonthCO.DataSource = months;
        ddlMonthCO.DataBind();
    
        int[] years = new int[] { 2015, 2016, 2017, 2018, 2019, 2020 };
    
        ddlYearCI.DataSource = years;
        ddlYearCI.DataBind();
        ddlYearCO.DataSource = years;
        ddlYearCO.DataBind();
    }
