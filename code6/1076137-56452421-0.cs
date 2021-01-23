public static void ExtractMessagePart(MessagePart part, ref EmailMessageModel message)
{
    if (part == null)
        return;
    var contentDisposition = part.Headers?.FirstOrDefault(h => h.Name == "Content-Disposition");
    if (contentDisposition != null && (contentDisposition.Value.StartsWith("attachment") || contentDisposition.Value == "inline"))
    {
        message.Attachments.Add(new DragnetTech.EventProcessors.Email.EmailMessageModel.Attachment
        {
            AttachmentId = part.Body.AttachmentId,
            Filename = part.Filename,
            ContentID = contentDisposition.Value.StartsWith("inline") || part.Headers?.FirstOrDefault(h => h.Name == "Content-ID") != null ? Utils.UnescapeUnicodeCharacters(part.Headers.FirstOrDefault(h => h.Name == "Content-ID")?.Value) : null,
            Size = part.Body.Size ?? 0,
            ExchangeID = part.Body.AttachmentId,
            Data = part.Body.Data,
            ContentType = part.Headers?.FirstOrDefault(h => h.Name == "Content-Type")?.Value
        });
    }
    else
    {
        if (part.MimeType == "text/plain")
        {
            message.Body = DecodeSection(part.Headers?.FirstOrDefault(h => h.Name == "Content-Transfer-Encoding")?.Value, part.Body?.Data);
            message.IsHtml = false;
        }
        else if (part.MimeType == "text/html")
        {
            message.Body = DecodeSection(part.Headers?.FirstOrDefault(h => h.Name == "Content-Transfer-Encoding")?.Value, part.Body?.Data);
            message.IsHtml = true;
        }
    }
    if (part.Parts != null)
    {
        foreach (var np in part.Parts)
        {
            ExtractMessagePart(np, ref message);
        }
    }
}
  [1]: https://sigparser.com/developers/email-parsing/gmail-api/#extracting-body-contents-and-attachments
