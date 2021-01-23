    protected void hoursReportGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        MyData myData = e.Row.DataItem as myData;
        if (myData != null && myData.DifferentUsers > 0)
        {
            e.Row.ForeColor = Color.Black;
            e.Row.BackColor = ColorTranslator.FromHtml("#fde16d");
        }
    }
