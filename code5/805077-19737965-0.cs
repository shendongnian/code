    class Program
    {
    static DataSet dtProfile = Database.AcquireData();
    static DataTable table = dtProfile.Tables[0];
    
    static string CustFName;
    static string CustLName;
    static string CheckoutDate;
    static string DueDate;
    static string BookName;
    
    public static void SendEmail()
    {
        StringBuilder body = new StringBuilder();
        foreach (DataRow row in table.Rows)
        {
         CustFName = row["CustFName"].ToString();
         CustLName = row["CustLName"].ToString();
         CheckoutDate = row["CheckoutDate"].ToString();
         DueDate = row["DueDate"].ToString();
         BookName = row["BookName"].ToString();          
         body.AppendLine(PopulateBody(CustFName, CustLName, CheckoutDate, DueDate, BookName, template));
         // not sure what your template looks like, but this would be whatever
         // markup or text you would want separating your book details
         body.AppendLine("<br>");
         
        }
        SendHtmlFormattedEmail("Email", "Subject", body.ToString());
    }
    
    public static string PopulateBody(string custFName, string custLName,
        string checkoutDate, string dueDate, string bookName)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Path.GetFullPath(@"Z:\folder\email.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{#First Name#}", custFName);
        body = body.Replace("{#Last Name#}",  custLName);
        body = body.Replace("{#Checkout Date#}", checkoutDate);
        body = body.Replace("{#Due Date#}",  dueDate);
        body = body.Replace("{#Book Name#}", bookName);
    
        return body;
    }
    
    public static void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
    {
        using (MailMessage mailMessage = new MailMessage())
        {
          mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
          mailMessage.Subject = subject;
          mailMessage.Body = body;
          mailMessage.IsBodyHtml = true;
          mailMessage.To.Add(new MailAddress(recepientEmail));
          SmtpClient smtp = new SmtpClient();
          smtp.Host = ConfigurationManager.AppSettings["Host"];
          smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
          System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
          NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
          NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
          smtp.UseDefaultCredentials = true;
          smtp.Credentials = NetworkCred;
          smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
          smtp.Send(mailMessage);
        }
    }
    
    static void Main(string[] args)
    {
        SendEmail();
    }
    
    }
 
