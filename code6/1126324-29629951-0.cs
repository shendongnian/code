            List<string> addyList = new List<string>();
            foreach (string line in File.ReadLines(Properties.Settings.Default.AddyList))
            {
                addyList.Add(line);
                // to add Name, you need to store emailAddress and name in  certain way so that you can parse Name out of the line in here
            }
			
			SmtpClient companySmtpClient = new SmtpClient("smtprelay.company.com");
            companySmtpClient.UseDefaultCredentials = true;
			MailAddress from = new MailAddress("ActiveBatchRunReport@company.com", "ActiveBatchRunReport");
            
			foreach(string address in addyList)
			{
				MailAddress to = new MailAddress(address);
				myMail.To.Add(to)
			}
            
            MailAddress ccKate = new MailAddress("Kate@company.com", "Kate");
            MailMessage myMail = new System.Net.Mail.MailMessage(from, to);
			
            myMail.CC.Add(ccKate);
            myMail.Subject = "Daily Job Runs";
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;
            myMail.Body = "Attached you will find an Excel spreadsheet" +
            "Total Job counts are listed at the bottom.";
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            myMail.IsBodyHtml = true;
            myMail.Attachments.Add(new Attachment(@"PathToAttachment"));
            companySmtpClient.Send(myMail);
