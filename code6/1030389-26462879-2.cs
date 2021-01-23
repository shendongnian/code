    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (checkcountry.Checked == true)
        {
            if (checkcountry.Checked == true && ddlCountry.SelectedIndex != 0 && ddlCountry.SelectedItem.Text == "India")
            {
                divForInida.Visible = true;
                divForOther.Visible = false;
            }
            else if (checkcountry.Checked == true && ddlCountry.SelectedIndex != 0 && ddlCountry.SelectedItem.Text != "India")
            {
                divForInida.Visible = false;
                divForOther.Visible = true;
            }
            else
            {
                //message for `Select a country of residence`
            }
        }
        else
        {
            //message for `check the checkbox`
        }
    }
