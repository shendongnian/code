                    if (message.HasAttachments && message.Attachments[0] is FileAttachment)
                    {
                        FileAttachment fileAttachment = message.Attachments[0] as FileAttachment;
                        Console.WriteLine("email" + fileAttachment.Name);
                        fileAttachment.Load(@"D:\\" + fileAttachment.Name);
                    }
