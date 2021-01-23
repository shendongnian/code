    private void editBTN_Click(object sender, EventArgs e)
    {
        bool notEditable = true;
        if(editBTN.Text == "Update")
        {
            UpdateDataBase();
            editBTN.Text = "Edit";
            deleteBTN.Visible = True;
            notEditable = true;
        }
        else
        {
            deleteBTN.Visible = false;
            editBTN.Text = "Update";
            deleteBTN.Visible = False;
            notEditable = false;
        }
        firstTxt.ReadOnly = notEditable;
        surenameTxt.ReadOnly = notEditable;
        address1Txt.ReadOnly = notEditable;
        address2Txt.ReadOnly = notEditable;
        countyTxt.ReadOnly = notEditable;
        contactTxt.ReadOnly = notEditable;
        emailTxt.ReadOnly = notEditable;
        postTxt.ReadOnly = notEditable;
    }
