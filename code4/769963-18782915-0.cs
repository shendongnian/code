    protected void Page_Load(object sender, EventArgs e)
    {
        //code what you currently have ....
        // add below code after that
        GridViewRow row  = GridView1.Rows.Count-1;
        row.BackColor = System.Drawing.Color.Firebrick;
        row.ForeColor = System.Drawing.Color.White;
    }
