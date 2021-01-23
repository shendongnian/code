    private void SendBulkEmail(List<KeyValuePair<Customer, Order>> customerList, MailAddress sender, string subject, string body, bool isHtml, string fileNamePrefix)
    {
        const int chunkSize = 20;
        string rootPath = Server.MapPath("~");
        string path = Path.GetFullPath(Path.Combine(rootPath, "Logs"));
        string fileName = CommonUtils.GetLogFileName(path, fileNamePrefix);
        int len = customerList.Count;
        TextWriter tw = new StreamWriter(fileName);
        int chunkCount = (len / chunkSize) + 1;
        int remainder = len % chunkSize;
        for (int j = 0; j < chunkCount; j++)
        {
           int start = j * chunkSize;
           int end = start + chunkSize;
           if (j == chunkCount - 1)
           {
               end = start + remainder;
           }
           SmtpClient client = new SmtpClient();
           for (int i = start; i < end; i++)
           {
               Customer customer = customerList[i].Key;
               Guid userGuid = new Guid(customer.UserId.ToString());
               MembershipUser membershipUser = Membership.GetUser(userGuid);
               string memberUsername = membershipUser.UserName;
               string memberEmail = membershipUser.Email;
                    
               SendMessage(sender, recipient, subject, body, tw, client, context);
                   
           }
           client.Dispose();
           Thread.Sleep(10000); // 10 seconds
           tw.WriteLine("Completed chunk #" + j);
       }
       tw.Close();
     }
    public static void SendEmail(MailAddress fromAddress, MailAddress toAddress, string subject, string body, TextWriter tw, SmtpClient smtpClient)
    {
        MailMessage message = new MailMessage(fromAddress, toAddress)
        {
           Subject = subject,
           Body = body
        };
        try
        {
           smtpClient.Send(message);
           if (tw != null)
           {
              tw.WriteLine("\"" + toAddress + "\",");
           }
        }
        catch (Exception ex)
        {
           if (tw != null)
           {
              tw.WriteLine(toAddress + ": " + ex.Message + " " + ex.InnerException.Message);
           }
           Debug.WriteLine("Cannot send e-mail to " + toAddress + ", " + "Exception: " + ex.Message + (ex.InnerException != null ? ", " + ex.InnerException.Message : string.Empty));
        }
    }
