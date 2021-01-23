    AttachmentFactory attachmentFactory =   (AttachmentFactory)TstTest.Attachments;
                TDAPIOLELib.Attachment attachment = (TDAPIOLELib.Attachment)attachmentFactory.AddItem("demoAttach.txt");
                attachment.Description = "Bug Sample Attachment";
                attachment.Post();
                IExtendedStorage exStrg = attachment.AttachmentStorage;
                exStrg.ClientPath = "E:\\TestData";
                exStrg.Save("demoAttach.txt", true);
