    private StorageFile storageFile;
    private async void ComposeEmail(String subject, String messageBody, StorageFile fl)
        {
            var msg = new EmailMessage();
            msg.Subject = subject;
            msg.Body = messageBody;
            msg.To.Add(new EmailRecipient("contact@123kidsfun.com"));
            String attachmentFile = fl.Name;
            if (fl != null && attachmentFile != "")
            {
                try
                {
                    var rastream = RandomAccessStreamReference.CreateFromFile(fl);
                    var attachment = new EmailAttachment(attachmentFile, rastream);
                    msg.Attachments.Add(attachment);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[C#] attachment exception: " + e.Message);
                }
            }
            try
            {
                await EmailManager.ShowComposeNewEmailAsync(msg);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[C#] email manager exception: " + e.Message);
            }
        }
        public void SendEmail(String subject, String body, String attachmentPath)
        {
            Debug.WriteLine("[C#] sendEmail(" + subject + ", " + body + ", " + attachmentPath + ")");
            Dispatcher.BeginInvoke(() =>
            {
                CreateEmail(subject, body, attachmentPath);
            });
        }
        private async void CreateEmail(String subject, String body, String path)
        {
            storageFile = await StorageFile.GetFileFromPathAsync(path);
            ComposeEmail(subject, body, storageFile);
        }
