    private async void button_Click(object sender, EventArgs e)
    {
       await SendEmailAsync(address, subject, body)
    }
    
    public async Task SendEmailAsync(string toAddress, string subject, string body, string code = null) 
    {
        try 
        {
            var fromAddressObj = new MailAddress("noreply@me.com", "Name");
            var toAddressObj = new MailAddress(toAddress, toAddress);
            const string fromPassword = "Password";
            var smtp = new SmtpClient {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddressObj.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddressObj, toAddressObj)
            {
                Subject = subject,
                IsBodyHtml = true
            }) 
            {
                message.Body = body;
                await smtp.SendMailAsync(message);
            }
        }
        catch (Exception e) 
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(e);
        }
    }
