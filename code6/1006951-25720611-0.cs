        public void ReadEmails()
        {
            MailRepository rep = new MailRepository("imap.gmail.com", 993, true, @"email@gmail.com", "password");
            DataTable dtMessages = new DataTable();
            dtMessages.Columns.Add("MessageNumber");
            dtMessages.Columns.Add("From");
            dtMessages.Columns.Add("Subject");
            dtMessages.Columns.Add("DateSent");
            int x = 0;
            //foreach (Message email in rep.GetUnreadMails("Inbox"))
            foreach (Message email in rep.GetAllMails("Inbox"))
            {
                dtMessages.Rows.Add();
                dtMessages.Rows[x]["MessageNumber"] = x;
                dtMessages.Rows[x]["From"] = email.From;
                dtMessages.Rows[x]["Subject"] = email.Subject;
                dtMessages.Rows[x]["DateSent"] = email.Date.ToShortDateString();
                ++x;
                if (x >= 20) break;
            }
            gvEmails.DataSource = dtMessages;
            gvEmails.DataBind();
        }
