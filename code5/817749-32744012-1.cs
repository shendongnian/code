    protected void GridViewTransaction_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.Header)
        {
            ImageButton btnExcelReport = new ImageButton();
            btnExcelReport.ID = "BtnExcelReport";
            btnExcelReport.ImageUrl = "images/excel.gif";
            btnExcelReport.ToolTip = "generate Excel report from result";
            btnExcelReport.Click += new ImageClickEventHandler(btnExcelReport_Click);
            e.Row.Cells[0].Controls.Add(btnExcelReport);
        }
    }
