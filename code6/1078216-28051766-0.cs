        static async void SendUsingOutlookClient(CommunicationRow me, OutlookServicesClient outlook)
        {
            var m = new Message();
            m.From = ToRecipient(me.From);
            m.Body = new ItemBody { Content = me.Body };
            if (me.IsBodyHtml)
                m.Body.ContentType = BodyType.HTML;
            else
                m.Body.ContentType = BodyType.Text;
            m.Subject = me.Subject;
            m.CcRecipients.Add(me.Cc);
            m.BccRecipients.Add(me.Bcc);
            m.ToRecipients.Add(me.To);
            outlook.Me.Messages.AddMessageAsync(m).Wait();
            foreach (var attach in me.Attachments)
            {
                var file = attach.File;
                var fileversion = file.GetVersion(attach.Version);
                string fullpath = LibraryServiceImpl.GetFullNameInArchive(fileversion);
                var mattach = new FileAttachment { Name = file.Name, ContentId = attach.ContentId, ContentLocation = fullpath, ContentType = GraphicUtils.DetermineMime(Path.GetExtension(fullpath)) };
                if (file.Name.MissingText())
                    mattach.Name = attach.ContentId + fileversion.FileExtension;
                m.Attachments.Add(mattach);
                await m.UpdateAsync();
            }
            await m.SendAsync();
        }
