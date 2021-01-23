     protected void GridViewAllSms_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnPrintEditedSms.Visible = false; //this doesn't work
            BtnPrintEditedSms.Enabled = false; //this also
            txtComplainant.Visible = true;     //this works
            Updatepanel1.Update();
        }
