      using Microsoft.Office.Interop.Outlook;
      var myApp = new Application();
      NameSpace mapiNameSpace = myApp.GetNamespace("MAPI");
      MAPIFolder myInbox = mapiNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      mapiNameSpace.SendAndReceive(false);
      if (myInbox.Items.Count > 0) {
        for (var i = 1; i < myInbox.Items.Count; i++) {
          string subject;
          var mailItem = myInbox.Items[i] as MailItem;
          if (mailItem != null) {
            subject = mailItem.Subject;
            if (!string.IsNullOrEmpty(subject)) {
              subject = subject.Replace('\'', '\"');
            }
          }
        }
      }
