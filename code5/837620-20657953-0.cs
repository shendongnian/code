    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuildChart();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuildChart();
    }
    private BuildChart()
    {
        var ddl3Value = DropDownList3.SelectedValue;
        var ddl2Value = DropDownList2.SelectedValue;
        if(ddl3Value != null && ddl2Value != null)
        {
            //build chart.
        }
    }
