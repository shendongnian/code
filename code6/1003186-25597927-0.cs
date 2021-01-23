    private void fusionButton1_Click(object sender, EventArgs e)
    {       
        MailMessage message = new MailMessage();
        message.From = new MailAddress("Sender@gmail.com");
        message.To.Add(new MailAddress(textBox4.Text));
        message.Subject =  textBox3.Text;
        message.Body =  textBox1.Text + " " + textBox2.Text; 
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);       
        client.Credentials = new NetworkCredential("Sender@gmail.com", "Pass");
        client.UseDefaultCredentials = false;
        client.EnableSsl = true;
        client.Send(message);
     }
