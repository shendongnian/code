    List<Attachment> screenshotAttachments = new List<Attachment>();
        foreach (var files in ScreenshotsOfIssueFiles)
        {
            if (files != null && files.ContentLength > 0)
            {
                var attachment = new Attachment(files.InputStream, files.FileName, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.FileName = Path.GetFileName(files.FileName);
                disposition.DispositionType = DispositionTypeNames.Attachment;
                screenshotAttachments.Add(attachment);
