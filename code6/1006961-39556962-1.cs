    protected void DownloadDocumentButton_OnClick(object sender, EventArgs e) {
      ASPxButton button = (ASPxButton) sender;
      int attachmentId = Convert.ToInt32(button.CommandArgument);
    
      var attachment = mAttachmentService.GenerateAttachment(attachmentId);
    
      Response.Clear();
      Response.AddHeader("content-disposition", $"attachment; filename={attachment.Name}");
      Response.AddHeader("content-type", attachment.ContentType);
      Response.BinaryWrite(Convert.FromBase64String(attachment.Base64));
      Response.End();
    }
