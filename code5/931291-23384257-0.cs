    string strReportUser = "RSUserName";
    string strReportUserPW = "MySecretPassword";
    string strReportUserDomain = "DomainName";
    
    string sTargetURL = "http://SqlServer/ReportServer?" +
       "/MyReportFolder/Report1&rs:Command=Render&rs:format=PDF&ReportParam=" +
       ParamValue;
    
    HttpWebRequest req =
          (HttpWebRequest)WebRequest.Create( sTargetURL );
    req.PreAuthenticate = true;
    req.Credentials = new System.Net.NetworkCredential(
        strReportUser,
        strReportUserPW,
        strReportUserDomain );
    
    HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
    
    Stream fStream = HttpWResp.GetResponseStream();
    
    HttpWResp.Close();
    //Now turn around and send this as the response..
    ReadFullyAndSend( fStream );
    ReadFullyAnd send method. NB: the SendAsync call so your not waiting for the server to send the email completely before you are brining the user back out of the land of nod.
    
    public static void ReadFullyAndSend( Stream input )
    {
       using ( MemoryStream ms = new MemoryStream() )
       {
          input.CopyTo( ms );
    
            MailMessage message = new MailMessage("from@foo.com", "too@foo.com");
                Attachment attachment = new Attachment(ms, "my attachment",, "application/vnd.ms-excel");
                message.Attachments.Add(attachment);
                message.Body = "This is an async test.";
    
                SmtpClient smtp = new SmtpClient("localhost");
                smtp.Credentials = new NetworkCredential("foo", "bar");
                smtp.SendAsync(message, null);
       }
    } 
