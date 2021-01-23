    using (MemoryStream stream = new MemoryStream())
        {
             ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
             object mailWriter = mailWriterContructor.Invoke(new object[] { stream });
             MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
             sendMethod.Invoke(mm, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { mailWriter, true, true }, null);
    
             Attachment emailAtt = new Attachment(stream, "Home Owner's Insurance Policy.msg");
    
             mm1.Attachments.Add(emailAtt);                                                                                                                                                                                                                       
     SmtpClient smtp1 = new SmtpClient();
     smtp1.Host = "HostIP";
     smtp1.Port = 25;
     try
         smtp1.Send(mm1);
    } // Ending using Clause
