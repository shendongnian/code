     MailMessage loginInfo = new MailMessage();
     loginInfo.To.Add("Emailaddress");
     loginInfo.From = new MailAddress("FromEmailaddress");
     loginInfo.Subject = "Subject";
     loginInfo.Body = "Body of the mail";
     loginInfo.IsBodyHtml = true;
     SmtpClient smtp = new SmtpClient();
     smtp.Host = hostname;
     smtp.Port = 25; //in my case i am using 25
     smtp.EnableSsl = false; //enable ssl is set to false
     smtp.Credentials = new System.Net.NetworkCredential(sEmailId, sPassword);
     smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
     smtp.Send(loginInfo);
     {
       Label.Visible = true;
       Label.Text = "A mail has been sent to you with the your username. Please check your inbox.";
     }
