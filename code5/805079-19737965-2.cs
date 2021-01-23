    class Program
    {
        static DataSet dtProfile = null; //Database.AcquireData();
        static DataTable table = dtProfile.Tables[0];
        public static void SendEmail()
        {
            // Create the dictionary to hold the email data for each individual email. This allows us 
            // to group all of the books due for an individual together.  We will use the email address
            // as the key for the dictionary instead of CustomerID in case the user has given us two
            // different email addresses.
            Dictionary<string, List<DataRow>> emailList = new Dictionary<string, List<DataRow>>();
            // Iterate over the dataset and populate the dictionary
            foreach (DataRow row in table.Rows)
            {
                // grab the email address, will be the key for the dictionary
                string email = row["Email"].ToString();
                // if we haven't processed a row for this email yet, initialize the entry for it
                if (!emailList.ContainsKey(email))
                {
                    emailList.Add(email, new List<DataRow>());
                }
                // add the datarow for the overdue book for the email
                emailList[email].Add(row);
            }
            // Now, craft and send an email for each unique email address in the list
            foreach (string email in emailList.Keys)
            {
                // create a string builder to build up the body of the email
                StringBuilder body = new StringBuilder();
                body.Append("<html>");
                body.Append("<body>");
                // assume the first/last name will be the same for each row, so just get the
                // name information from the first row to build the opening line of the email
                DataRow firstRow = emailList[email][0];
                body.AppendFormat("<p>Dear {0} {1}:  The following book(s) are due:</p>", firstRow["FName"].ToString(), firstRow["LName"].ToString());
                body.Append("<ol>");
                // now just add a line item for each book
                foreach (DataRow row in emailList[email])
                {
                    body.AppendFormat("<li>{0}</li>", row["BookName"].ToString()); 
                }
                // close up your html tags
                body.Append("</ol>");
                body.Append("</body>");
                body.Append("</html>");
                // finally, send the email
                SendHtmlFormattedEmail(email, "Overdue Books", body.ToString());
            }
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
 
