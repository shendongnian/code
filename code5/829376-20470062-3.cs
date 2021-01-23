    protected void Buttonmail_Click(object sender, EventArgs e)
    {
        fn_AttachGrid();
    }
    public void fn_AttachGrid()
    {
        StringWriter sWriter = new StringWriter();
        HtmlTextWriter hWriter = new HtmlTextWriter(sWriter);
        GridView1.RenderControl(hWriter);
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = true;
        mail.To.Add(new MailAddress(txtto.Text));
        mail.Subject = "Foi";
        System.Text.Encoding Enc = System.Text.Encoding.ASCII;
        byte[] mBArray = Enc.GetBytes(sWriter.ToString());
        string style = @"<style> TD { mso-number-format:\@; } </style>";
        Response.Write(style);
        System.IO.MemoryStream mAtt = new System.IO.MemoryStream(mBArray, false);
        mail.Attachments.Add(new Attachment(mAtt, "rotina.xls"));
        mail.Body = "Foi detectado o seguinte problema";
        SmtpClient smtp = new SmtpClient();
        mail.From = new MailAddress("dancake.si.2012@gmail.com", "Sistemas de Informação");
        smtp.Host = "smtp.gmail.com";
        smtp.UseDefaultCredentials = true;
        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        NetworkCred.UserName = "dancake.si.2012@gmail.com";
        NetworkCred.Password = "Pa$$w0rd2012";
        smtp.Credentials = NetworkCred;
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(mail);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Enviado com sucesso.');", true);
    }
