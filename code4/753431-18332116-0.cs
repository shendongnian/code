    protected void btnsendEmail_Click(object sender, EventArgs e)
        {
            try
            {
    
    
                char[] split = { ';' };
    
                foreach (string mailAdd in txtemailAdd.Text.Split(split))
                {
                  sendMail(mailAdd);
    
    
                }
              // mail is successfully sent :-
              Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Msg", "alert('Mail sent successfully')", true);
            }
            catch (Exception ex)
            {
                         // mail is not successfully sent :-
              Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Msg", "alert('Mail not sent successfully')", true);
            }
    }
