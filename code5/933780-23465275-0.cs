    protected void cmdbox_TypePayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmdbox_TypePayment.SelectedIndex == 0)
        {
           lblCaption.Visible = false;
           txt_Carte.Visible = false;
           txt_CarteNum.Visible = false;
           txt_CarteDate.Visible = false;
           txt_CarteCCV.Visible = false;
        }
    
        else if (cmdbox_TypePayment.SelectedIndex == 1)
        {
           lblCaption.Visible = true;
           txt_Carte.Visible = true;
           txt_CarteNum.Visible = true;
           txt_CarteDate.Visible = true;
           txt_CarteCCV.Visible = true;
        }
    }
