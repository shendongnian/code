    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(YourEmail.Text);
                // Recipient e-mail address.
                Msg.To.Add("test@gmail.com");
                Msg.Subject = YourSubject.Text;
                Msg.Body = Comments.Text;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("YOURGMAILID", "YOURGMAIL PASSWORD");  // IT SHOULD BE CORRECT TO WORK
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                //Msg = null;
               // DisplayMessage.Text = "Thanks for Contacting us";
                // Clear the textbox valuess
                YourName.Text = "";
                YourSubject.Text = "";
                Comments.Text = "";
                YourEmail.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
