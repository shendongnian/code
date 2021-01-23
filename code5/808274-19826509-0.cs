    public void SendEmail(EmailGT x)
    {
        string destinatario = x.destinatario;
        string mensagem = x.mensagem;
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.To.Add(destinatario);
        message.Subject = "something";
        message.Body = mensagem;
    }
