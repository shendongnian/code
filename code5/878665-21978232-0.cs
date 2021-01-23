    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Page.IsPostBack)
        {
            var ie =
            (from ac in db.ITdevicedetails where ac.IDdevice == "note01" select ac).FirstOrDefault();
            //this is my answer !!!
            TextBox xp = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0]));
            ie.Comment = xp.Text;
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            binded();
        }
    
    }
