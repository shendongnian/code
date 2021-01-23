                //Retrieve ActivityMimeAttachment
                ActivityMimeAttachment attachmentMimeTemp;
                attachmentMimeTemp = (ActivityMimeAttachment)handlerCrm.CrmService.Retrieve(ActivityMimeAttachment.EntityLogicalName, Guid.Parse(row["ActivityMimeAttachmentId"].ToString()), new ColumnSet(true));
                //delete the old attachment (kit)
                handlerCrm.CrmService.Delete(ActivityMimeAttachment.EntityLogicalName, attachmentMimeTemp.Id);
                //create new attachment to the Email
                ActivityMimeAttachment newAttachment = new ActivityMimeAttachment
                {
                    ObjectId = attachmentMimeTemp.ObjectId,
                    ObjectTypeCode = "email",
                    Body = System.Convert.ToBase64String(
                                    new ASCIIEncoding().GetBytes("Example Attachment")),
                    FileName = String.Format("newFile")
                };
                handlerCrm.CrmService.Create(newAttachment);
