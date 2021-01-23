    Public Sub SendEmailWithFile(strEmailSubject, fromEmail, fileAttachment)
     Dim emlEmail As Net.Mail.MailMessage = s.GetMailMessage()
     Dim smtp As Net.Mail.SmtpClient = New Net.Mail.SmtpClient
     emlEmail.To.Add(user.EmailAddress)
     If Not String.IsNullOrEmpty(configurationManager.AppSettings("additionalEmailTo")) Then
      Dim address As String = configurationManager.AppSettings("additionalEmailTo")
      emlEmail.To.Add(address)
     End If
    ...
     If fileAttachmentIsNot Nothing Then
        emlEmail.Attachments.Add(fileAttachment)
     End If
     smtp.Send(emlEmail)//1
     End Sub
