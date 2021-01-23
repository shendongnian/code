    protected void form1_Load(object sender, EventArgs e)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataRow dr;
        dt.Columns.Add("NDAid");
        dt.Columns.Add("ComName");
        dt.Columns.Add("Country");
        dt.Columns.Add("Date");
        for (int i = 1; i <= 5; i++)
        {
            dr = dt.NewRow();
            dr[0] = i;
            dr[1] = "Company " + i;
            dr[2] = "Country " + i;
            dr[3] = DateTime.Now;
            dt.Rows.Add(dr);
        }
        grdNDA.DataSource = dt;
        grdNDA.DataBind();
    }
    protected void grdNDA_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblValues.Text = "<b>ID:</b> " + grdNDA.SelectedRow.Cells[1].Text;
    }
