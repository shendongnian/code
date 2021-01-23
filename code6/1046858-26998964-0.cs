    protected void DetailsView1_ItemCommand(object sender, System.Web.UI.WebControls.DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Update" || e.CommandName == "Insert")
        {
            //Frequency
            DropDownList FreqDDL = (DropDownList)DetailsView1.FindControl("DropDownList4");
            if (FreqDDL.SelectedIndex > 0)
            {
                var FreqTbox = (TextBox)DetailsView1.FindControl("TextBox4");
                FreqTbox.Text = FreqTbox.Text + FreqDDL.Text;
            }
            //Power
            DropDownList PowerDDL = (DropDownList)DetailsView1.FindControl("DropDownList5");
            if (PowerDDL.SelectedIndex > 0)
            {
                var PowerTbox = (TextBox)DetailsView1.FindControl("TextBox5");
                PowerTbox.Text = PowerTbox.Text + PowerDDL.Text;
            }
            //Bandwidth
            DropDownList BwidthDDL = (DropDownList)DetailsView1.FindControl("DropDownList6");
            if (BwidthDDL.SelectedIndex > 0)
            {
                var BwidthTbox = (TextBox)DetailsView1.FindControl("TextBox6");
                BwidthTbox.Text = BwidthTbox.Text + BwidthDDL.Text;
            }
        }
    } 
