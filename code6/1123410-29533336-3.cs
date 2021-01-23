    protected void Page_Load(object sender, EventArgs e)
        {
            var message = (MailMessage)MyMailMessage();
            var stream = FromMailMessageToMemoryStream(message);
            List<string> bccTo = new List<string>();
            bccTo.Add("chris@domain.com");
            using (AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient("awsAccessKeyId", "awsSecretAccessKey", RegionEndpoint.USWest2))
            {
                var sendRequest = new SendRawEmailRequest { RawMessage = new RawMessage { Data = stream } };
                var response = client.SendRawEmail(sendRequest);
                Console.WriteLine(response.MessageId);
                if (bccTo != null && bccTo.Count > 0)
                {
                    sendRequest.Destinations = bccTo;
                    response = client.SendRawEmail(sendRequest);
                    Console.WriteLine(response.MessageId);
                }
            }
        }
    private static MailMessage MyMailMessage()
        {
            var message = new MailMessage();
            message.From = new MailAddress("rpatel.alld@Gmail.com", "rahul");
            message.To.Add("rpatel.alld@Gmail.com");
            message.Subject = "Hello";
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(@"<p>Thank you for submitting your query/complaint.", new ContentType("text/html")));
            //
            string attachmentname = "IntelOCL.log";
            Stream ms = new MemoryStream(File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(Path.GetFileName(attachmentname))));
            ContentType ct = new ContentType();
            ct.MediaType = "" // TODO
            Attachment attachment = new Attachment(ms, ct);
            attachment.Name = attachmentname;
            attachment.ContentDisposition.FileName = attachmentname;
            message.Attachments.Add(attachment);
            return message;
        }
