    protected void btnsubmitclass_OnClick(object sender,EventArgs e)
    {
        if(rbchoice.SelectedIndex==0)
        {
        if(drpfromclass.SelectedIndex>0 && drptoclass.SelectedIndex>0)
        {
            ds = objpromote.selectclasswise(ConfigurationManager.AppSettings["schoolcode"].ToString(),drpfromclass.SelectedItem.Value,drptoclass.SelectedItem.Value);
            if(ds.Tables[0].Rows.Count>0)
            {
                grdstudents.Visible = true;
                grdstudents.DataSource = ds;
                grdstudents.DataBind();
                lblheading.Text = "Showing list of students moved from " + drpfromclass.SelectedItem.Text + " to " + drptoclass.SelectedItem.Text;
                pnlgrd.Visible = true;
            }
            else
            {
                pnlgrd.Visible = false;
                lblalerts.Text = "No record found";
                lblalerts.Visible = true;
                divalerts.Visible = true;
            }
            drpfromclass.ClearSelection();
            drptoclass.ClearSelection();
        }
        else
        {
            lblalerts.Text = "Select fromclass and toclass";
            lblalerts.Visible = true;
            divalerts.Visible = true;
            pnlgrd.Visible = false;
        }
        }
        else
        {
            if (drpclass.SelectedIndex > 0 && drpstudent.SelectedIndex > 0)
        {
            ds = objpromote.selectstudentwise(ConfigurationManager.AppSettings["schoolcode"].ToString(),drpstudent.SelectedItem.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdstudents.Visible = true;
                grdstudents.DataSource = ds;
                grdstudents.DataBind();
                lblheading.Text = "Showing detailed list of "+drpstudent.SelectedItem.Text+" of class- "+drpclass.SelectedItem.Text;
                pnlgrd.Visible = true;
            }
            else
            {
                lblalerts.Text = "No record found";
                lblalerts.Visible = true;
                divalerts.Visible = true;
                pnlgrd.Visible = false;
            }
            drpclass.ClearSelection();
            drpstudent.ClearSelection();
        }
        else
        {
            lblalerts.Text = "Select fromclass and toclass";
            lblalerts.Visible = true;
            divalerts.Visible = true;
            pnlgrd.Visible = false;
        }
        }
    }
