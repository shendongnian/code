    public FrmPatientSearch(string _email,string _password)
    {
       InitializeComponent();
       Email = _email;
       Password = _password;
    }
    string Email = sting.Empty;
    string Password = string.Empty;
    
    private void btnSend_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    
        mail.From = new MailAddress(Email ,"Pavel Valeriu");
        mail.To.Add(textBoxTo.Text);
        mail.Subject = textBoxSubject.Text;
        mail.Body = richText.Text;
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("pavelvaleriu24@gmail.com", Password );
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        MessageBox.Show("mail Send");
        Close();
    }
