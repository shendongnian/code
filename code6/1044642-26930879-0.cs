    private void timer1_Tick(object sender, EventArgs e)
        {
            alertDataSetTableAdapters.tbl_AutoAssignCadTeamTableAdapter EM;
            EM = new alertDataSetTableAdapters.tbl_AutoAssignCadTeamTableAdapter();
            DataTable dt = new DataTable();
            dt = EM.GetEmpMail();
            string[] emails = dt.AsEnumerable().Select(x => x.Field<String>("Email")).ToArray();
            MailMessage loginInfo = new MailMessage();
            foreach (var email in emails)
            {
                loginInfo.To.Add(email);
            }
            loginInfo.From = new MailAddress("fromID@gmail.com");
            loginInfo.Subject = "Hai";
            loginInfo.Body = "Hai";
            loginInfo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("fromID@gmail.com", "***");
            smtp.Send(loginInfo);
        }
