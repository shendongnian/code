    public partial class Form1 : Form
    {
        Thread t = null;
        //MailMessage mailMessage;  <-- take out this line
        void sentEmail(Object array)
        {
            Object[] o = array as Object[];
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
            MailMessage mailMessage = new MailMessage(new MailAddress(o[0].ToString()), new MailAddress(o[1].ToString()));  // <-- don't use the Form property
            mailMessage.Body = textBox3.Text;
            mailMessage.Subject = textBox2.Text;
            client.Send(mailMessage);
        }
