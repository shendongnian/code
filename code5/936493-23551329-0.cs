    public override System.Net.Mail.MailMessage GenerateMessage()
    {
    var keys = new Dictionary<string, string>();
    var fileBytes = new Dictionary<byte[], string>();
    var attachments = new List<System.Net.Mail.Attachment>();
    var message = new MailMessage();
    //get the attachment images as html in a dictionary object, byte[] and string   
    fileBytes = GetEmailAttachments();
    var resourceList = new List<LinkedResource>();
    foreach (var imageBytes in fileBytes)
    {
    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(new MemoryStream(imageBytes.Key), MediaTypeNames.Image.Jpeg);
    attachment.Name = imageBytes.Value;
    attachment.ContentDisposition.Inline = true;
    attachment.ContentId = imageBytes.Value;
    //attachments.Add(attachment);
    var stream = new MemoryStream(imageBytes.Key);
    var newResource = new LinkedResource(stream, "image/jpeg");
    newResource.TransferEncoding = TransferEncoding.Base64;
    newResource.ContentId = imageBytes.Value;
    resourceList.Add(newResource);
    }
    foreach (var attachment in resourceList)
    {
    //message.Attachments.Add(attachment);
    //string fileName = attachment.Name.Split('.')[0];
    string fileName = attachment.ContentId.Split('.')[0];
    switch (fileName)
    {
        case "img-approve":
            keys.Add(fileName, String.Format("<a href={0} target=_top><img src='cid:{1}' alt={2} title={3}></a>", 
                innerMsg, attachment.ContentId, fileName, "test"));
            break;
        case "img-reject":
            keys.Add(fileName, String.Format("<a href={0} target=_top><img src='cid:{1}' alt={2} title={3}></a>", 
                innerMsg1, attachment.ContentId, fileName, "test"));
            break;
        case "img-buyer":
            keys.Add(fileName, String.Format("<a href={0} target=_top><img src='cid:{1}' height=100 alt=picture></a>", imageURL, attachment.ContentId));
            break;
        case "img-env":
            keys.Add(fileName, String.Format("<img src='cid:{0}' alt={1} style=vertical-aign: middle>", attachment.ContentId, "test"));
            break;
        case "img-computer":
            keys.Add(fileName, String.Format("<img src='cid:{0}' alt={1} style=vertical-aign: middle>", attachment.ContentId, "test"));
            break;
        case "logo":
            keys.Add(fileName, String.Format("<img src='cid:{0}' alt={1} style=vertical-aign: middle>", attachment.ContentId, "test"));
            break;
        default:
            keys.Add(fileName, String.Format("<img src='cid:{0}' alt={1}>", attachment.ContentId, fileName));
            break;
    }
    }
    //get the additional keys specific to this email
    GenerateAdditionalKeys(keys, message);
    //build the email
    var body = ReplaceTemplateKeys(keys, _template);
    if(!string.IsNullOrEmpty(toEmail))
    {
        message.To.Add(toEmail);
    }
    if (!string.IsNullOrEmpty(ccEmail))
    {
        message.CC.Add(ccEmail);
    }
    message.IsBodyHtml = true;
    //message.Body = body;
    return message;
    }
