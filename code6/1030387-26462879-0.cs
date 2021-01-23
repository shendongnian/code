    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (checkcountry.Checked == true)
        {
            if (checkcountry.Checked == true && ddlCountry.SelectedIndex != 0 && ddlCountry.SelectedItem.Text == "India")
            {
                //DO for INDIA
            }
            else if (checkcountry.Checked == true && ddlCountry.SelectedIndex != 0 && ddlCountry.SelectedItem.Text != "India")
            {
                //Do for other
            }
        }
        else
        {
            //alert for check
        }
    }
