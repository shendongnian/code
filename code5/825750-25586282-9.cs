            var mailMessage = new MailMessage();
            mailMessage.From = "someone@yourdomain.com";
            mailMessage.Subject = "Your subject here";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<span style='font-size: 12pt; color: red;'>My HTML formatted body</span>";
            mailMessage.Attachments.Add(new Attachment("C://Myfile.pdf"));
            var filename = "C://Temp/mymessage.eml";
            
            //save the MailMessage to the filesystem
            mailMessage.Save(filename);
            //Open the file with the default associated application registered on the local machine
            Process.Start(filename);
