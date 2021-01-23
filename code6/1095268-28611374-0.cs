    protected void Btn1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
        string rute = gvRow.Cells[0].Text;
        string rute1 = gvRow.Cells[1].Text;
        string rute2 = gvRow.Cells[2].Text;
        string rute3 = gvRow.Cells[3].Text;
        string rute4 = gvRow.Cells[4].Text;
    }
