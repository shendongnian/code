    void Sendmail_Click(object sender, EventArgs e)
            {
    
                List<DAL.Customer> mailId = (from rs in General.db.Customers
                                             where rs.IsActive == true
                                             select rs).ToList();
    
                SmtpClient smtp = new SmtpClient();
                mailMessage.From = fromMail;
                mailMessage.IsBodyHtml = true;
                foreach (var item in mailId)
                {
                   mailMessage.To.Add(new MailAddress(item.Email));
                }
                lblStatus.Text = "Email sent successfully";
    
        }
