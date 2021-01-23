    using(SmtpClient smtp = new SmtpClient(smtpserver, 25))
    {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(email_From);
            msg.To.Add(email_Recipient);
            msg.IsBodyHtml = true;
            msg.Subject = email_Subject;
            ///Attachment's and Body
            try
            {
                    _f3.ShowDialog(); //until you dont close the dialog, it will not send the msg. Maybe _f3.Show() solve your problem
                    smtp.Send(msg);
                    MessageBox.Show("Email Successfully Sent!!!", "Mail!!!.");
                    //Environment.Exit(0);// -->> if i keep this mail is going.. else i have to close
                    // my application to receive mail
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
    }
