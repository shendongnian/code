    // Attach the btnSend click event where it is created or before it suites better in you code.
    btnsend.Click += btnsend_Click;
            void btnsend_Click(object sender, RoutedEventArgs e)
            {
                MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.google.com";
                mail.To.Add("reciever@example.com");
                mail.Subject = textbox1.Text;
                mail.Body = textbox2.Text;
                client.Send(mail);
            }
