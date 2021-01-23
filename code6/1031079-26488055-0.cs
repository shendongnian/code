    foreach (GridViewRow item in LoadEmails.Rows) 
    {
        Label lblEmail = (Label)item.FindControl("Label5");
        if(lblEmail != null)
        {
            string email = lblEmail.Text;
            //do email sending 
        }
    }
