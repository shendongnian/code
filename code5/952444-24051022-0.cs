                FolderId Inboxid = new FolderId(WellKnownFolderName.Inbox, "target@domain.com");    
            ItemView InboxItemView = new ItemView(1);
            FindItemsResults<Item> inFiResuls = service.FindItems(Inboxid,InboxItemView);
            if(inFiResuls.Items.Count == 1){
                EmailMessage fwdMail = new EmailMessage(service);
                EmailMessage orgMail = (EmailMessage)inFiResuls.Items[0];
                PropertySet psPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
                psPropSet.Add(ItemSchema.MimeContent);
                orgMail.Load(psPropSet);
                ItemAttachment emAttach = fwdMail.Attachments.AddItemAttachment<EmailMessage>();
                emAttach.Item.MimeContent = orgMail.MimeContent;
                ExtendedPropertyDefinition pr_flags = new ExtendedPropertyDefinition(3591,MapiPropertyType.Integer);
                emAttach.Item.SetExtendedProperty(pr_flags,"1");
                emAttach.Name = orgMail.Subject;
                fwdMail.Subject = "see Attached";
                fwdMail.ToRecipients.Add("user@domain.com");
                fwdMail.Send();
            }
