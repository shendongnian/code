      RDOSesssion Session = new RDOSession();
      Session.Logon();
      RDOFolder Folder = Session.GetDefaultFolder(rdoDefaultFolders.olFolderSentMail);
      RDOMail Msg = Folder.Items.Add("IPM.Note");
      Msg.Sent = true; //must be done before calling Save!
      RDORecipient Recip = Msg.Recipients.Add("user@domain.demo");
      Recip.Resolve();
      Msg.Subject = "test";
      Msg.Body = "test body";
      Msg.SentOn = Now;
      Msg.Save();
