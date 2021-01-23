    protected void btnSend_Click(object sender, EventArgs e)
    {
         try
            {
                ...ALL THE PREVIOUS CODE...
        
                            mailMessage.Body = GenerateMessage(email);
                            mailMessage.BodyEncoding = Encoding.UTF8;
                            mailMessage.IsBodyHtml = true;
    
               ... REST OF THE CODE
            }
        catch()
        {}
     }
        
        private string GenerateMessage(string email)
        {
           var sb = new StringBuilder();
           sb.Append("<b>Email: </b>");
           sb.Append(string.Format("<br> {0} <br>",email));
           //.
           //.Rest of the stuff here
           //..
           return sb.ToString();
        }
