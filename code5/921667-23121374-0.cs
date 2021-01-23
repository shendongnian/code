    // Note: if the email addresses do not match the certificates, you can
    // use a SecureMailboxAddress instead, which allows you to specify the
    // Fingerprint (aka Thumbprint) of the certificate to use for signing
    // or encrypting.
    var recipient = new MailboxAddress ("Receiver Name", "receiver@example.com");
    var sender = new MailboxAddress ("Sender Name", "sender@example.com");
    var message = new MimeMessage ();
    message.To.Add (recipient);
    message.From.Add (sender);
    message.Subject = subject;
    // create the application/edifact MIME part
    var edifact = new MimePart ("application", "edifact");
    // set the filename of the MIME part (adds a Content-Disposition header
    // if not already present)
    edifact.FileName = subject + ".edi";
    // create the content stream of the MIME part
    var content = new MemoryStream (Encoding.UTF8.GetBytes (ediMsg), false);
    // set the content of the MIME part (we use ContentEncoding.Default because
    // it is not encoded... yet)
    edifact.ContentObject = new ContentObject (content, ContentEncoding.Default);
    // encode the content using base64 *and* set the Content-Transfer-Encoding header
    edifact.ContentTransferEncoding = ContentEncoding.Base64;
    using (var ctx = new TemporarySecureMimeContext ()) {
        ctx.Import (clientCertificatePath, clientCertificatePassword);
        ctx.Import (customsCertificatePath);
        // sign and then encrypt the edifact part and then set the result as the
        // message body.
        message.Body = ApplicationPkcs7Mime.SignAndEncrypt (ctx, sender,
            DigestAlgorithm.Sha1, new [] { recipient }, edifact);
    }
    // MailKit's SMTP API is very similar to System.Net.Mail's SmtpClient API,
    // so that shouldn't pose a problem.
