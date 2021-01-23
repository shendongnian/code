    protected void btn_Click(object sender, EventArgs e)
    {
        var dates = formattedDates.Select(DateTime.Parse);
        GridView2.DataSource = CreateDatesTable(dates);
        GridView2.DataBind();
    }
    
