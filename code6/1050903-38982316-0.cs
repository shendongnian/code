    MailMessage mailMessage = new MailMessage();
    while (dr.Read())
    {
    //Your code from HERE
        mailMessage.To.Add(new MailAddress(dr["EmailAddress"].ToString()));
        if ((bool)dr["SecondaryNotify"])
            mailMessage.Bcc.Add(new MailAddress(dr["SecondaryEmail"].ToString()));
        // Send email
        ...
        //Then email delete from .To
        int iMessageInArray = mailMessage.To.Count(); //Finds the amount of emails in the array
        if(iMessageInArray > 0)
        {
           for(int i = 0; i < iMessageInArray; i++)
           {
               mailMessage.To.Remove(mailMessage.To[0]); //When one line is removed, the next email comes in index 0 of the array.
            }
        }
    }
