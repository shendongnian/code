                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(strPDFPath);
                Stream stream = new MemoryStream(FileBuffer);
                ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);
                pdf = new Attachment(stream, ct);
                pdf.ContentType.MediaType = MediaTypeNames.Application.Pdf;
                msg.Attachments.Add(pdf);
                pdf.ContentType.Name = Path.GetFileName(strPDFPath);
