	void OutlookApplication_ItemSend(object Item, ref bool Cancel)
        {
            
            if (Item is Outlook.MailItem)
            {
                Outlook.Inspector currInspector;
                currInspector = outlookApplication.ActiveInspector();
                Outlook.MailItem oldMailItem = (Outlook.MailItem)Item;
                Outlook.MailItem mailItem = oldMailItem.Copy();
                string image = "<img src='http://someserver.com/attach.jpg' width=\"1\" height=\"1\" alt=\"\" />";
                string body = mailItem.HTMLBody;
				
                body = body.Replace("</body>", image+"</body>");
				
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.HTMLBody = body;
				
                mailItem.Send();
                Cancel = true;
                currInspector.Close(Outlook.OlInspectorClose.olDiscard);
            }
        }
