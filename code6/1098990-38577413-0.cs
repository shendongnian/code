    private void outLookApp_NewMailEx(string EntryIDCollection)
        {
            olNameSpace = this.Application.GetNamespace("MAPI");
            try
            {
                //THIS part is failing \/ and returning nothing
                object item = olNameSpace.GetItemFromID(EntryIDCollection, Type.Missing);
                Outlook.MailItem mailItem = item as Outlook.MailItem;
                
                if (mailItem != null)
                {
                    mailItem.Display();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }
