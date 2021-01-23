    foreach (Control c in pnlMailingPanel.Controls)
    {
        MailingReference mailingReference = c as MailingReference;
        if (mailingReference != null)
        {
            foreach (Control c2 in mailingReference.Controls)
            {
                //do work
            }
        }
    }
