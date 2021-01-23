    Stringbuilder sb = new StringBuilder();
    sb.Append("Field1:" + Field1.Text);
    sb.AppendLine("<br />"); //use AppendLine so that source looks pretty. Use HTML break so that the rendered text has a new line
    
    
    public static void SendMail(MailMessage mail)
        {
        mail.IsBodyHtml=true;
        //send the email
        }
