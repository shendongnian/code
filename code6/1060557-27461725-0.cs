    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        lbltxtqty.Visible = true;
        lbltxtqty.Text = ((TextBox)GridView1.Rows[0].FindControl("txtqtys")).Text;
    }
