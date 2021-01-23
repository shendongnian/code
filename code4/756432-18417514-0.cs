    string[] mails = new string[4];
        ListViewItem itm;
        Private Outlook.Application app = new Outlook.Application();
        private void comboBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFolder.SelectedIndex == 0)
            {
                    
                    Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
                    Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    foreach (Outlook.MailItem item in emailFolder.Items)
                    {
                        mails[0] = item.SenderEmailAddress;
                        mails[1] = item.To;
                        mails[2] = item.Subject;
                        mails[3] = Convert.ToString(item.ReceivedTime);
                        itm = new ListViewItem(mails);
                        listViewEmail.Items.Add(itm);
                    }
                
            
            
            }
        }
