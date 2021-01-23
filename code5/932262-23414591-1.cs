    oBLL.Comments = "<strong>Comments:</strong>" + txtComments.Text;
    mailBody.Append(oBLL.Comments);
    // ...
    // assuming mail client and message instances already exists
    mailMessage.IsBodyHtml = true;
    mailClient.Send(mailMessage);
