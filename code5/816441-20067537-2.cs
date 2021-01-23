    protected void Buttonmail_Click(object sender, EventArgs e)
    {
        fn_AttachGrid();
    }
    public void fn_AttachGrid()
    {
        StringWriter sWriter = new StringWriter();
        HtmlTextWriter hWriter = new HtmlTextWriter(sWriter);
        GridView1.RenderControl(hWriter);
        Response.Output.Write(sWriter.ToString());
       
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.To.Add(new MailAddress("receiver@domain.pt"));
        mail.Subject = "Sales Report";
        System.Text.Encoding Enc = System.Text.Encoding.ASCII;
        byte[] mBArray = Enc.GetBytes(sWriter.ToString());
        System.IO.MemoryStream mAtt = new System.IO.MemoryStream(mBArray, false);
        mail.Attachments.Add(new Attachment(mAtt, "dad.xls"));
        mail.Body = "Hi PFA";
        SmtpClient smtp = new SmtpClient();
        mail.From = new MailAddress("sender@gmail.com", "name");
        smtp.Host = "smtp.gmail.com";
        smtp.UseDefaultCredentials = true;
        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        NetworkCred.UserName = "sender@gmail.com";
        NetworkCred.Password = "password";
        smtp.Credentials = NetworkCred;
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(mail);
        Label1.Text = "Email Sent";
    }
