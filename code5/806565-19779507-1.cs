    protected void btnSend_Click(object sender, EventArgs e) {
        Trace.Write("btnSend_Click initialized");
        string resp = "An unknown error occured.";
        using (MailMessage msg = new MailMessage()) {
            try {
                msg.To.Add(txtFrom.Text);
                msg.Subject = txtSubject.Text;
                msg.Body = txtMessage.Text;
                SmtpClient smtp = new SmtpClient("localhost");
                Trace.Write("smtp client created.");
                smtp.Send(msg);
                Trace.Write("smtp message sent.");
                resp = "Your message was sent.";
            } catch (Exception ex) {
                Trace.Warn("Smtp Error", ex.Message);
                resp = "There was an error sending your message.";
            }
        }
        Response.Write(resp);
        Trace.Write("btnSend_Click completed");
    }
