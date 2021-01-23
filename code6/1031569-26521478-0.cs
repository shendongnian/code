            foreach (Attachment Attach in EWSItem.Attachments)
            {
                if (Attach is ItemAttachment)
                {
                    PropertySet psProp = new PropertySet(BasePropertySet.FirstClassProperties);
                    psProp.Add(ItemSchema.MimeContent);
                    ((ItemAttachment)Attach).Load(psProp);
                    if (((ItemAttachment)Attach).Item.MimeContent != null)
                    {
                        EmailMessage NewMessage = new EmailMessage(service);
                        NewMessage.MimeContent = ((ItemAttachment)Attach).Item.MimeContent;
                        NewMessage.SetExtendedProperty(new ExtendedPropertyDefinition(3591, MapiPropertyType.Integer), "1");
                        NewMessage.Save(folderItemToMove.Id);
                    }
                }
            }  
