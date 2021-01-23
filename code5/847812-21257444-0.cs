    public void MyMailFunction()
        {
            while (true)
            {
                bool SwitchSMTP = false;
                using (var db = whatEverContext())
                {
                    var q = from s in db.mail select s;
                    var myList = q.ToList.Take(25);
                    if (myList.Count() == 0)
                    {
                        break; 
                    }
                    if (!SwitchSMTP)
                        {
                            SendMails(myList, 25, "smtp.gmail.com", "myusername", "mypassword");
                            SwitchSMTP = true;
                        }
                        else
                        {
                            SendMails(myList, 25, "smtp.gmail.com", "myusername", "mypassword");
                            SwitchSMTP = false;
                        }
                     
                    
                }
            }
        }
        internal void SendMails(IEnumerable<Mail> myList, int port, string host, string username, string password)
        {
            SmtpClient client = new SmtpClient();
            client.Port = port;
            client.Host = host;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            foreach (var m in myList)
            {
                MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(mm);
            }
            client.Dispose();
        }
           
