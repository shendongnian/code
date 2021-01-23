    using System;
    using System.IO;
    using System.Net.Mail;
    using System.Reflection;
    namespace Fsolutions.Fbase.Common.Mail
    {
        public static class MailUtility
        {
            //Extension method for MailMessage to save to a file on disk
            public static void Save(this MailMessage message, string fileName, bool addUnsentHeader = true)
            {
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    var assembly = typeof(SmtpClient).Assembly;
                    var mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
                    // Get reflection info for MailWriter contructor
                    var mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
                    // Construct MailWriter object with our FileStream
                    var mailWriter = mailWriterContructor.Invoke(new object[] { fileStream });
                    // Get reflection info for Send() method on MailMessage
                    var sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
                    sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { mailWriter, true, true }, null);
                    // Finally get reflection info for Close() method on our MailWriter
                    var closeMethod = mailWriter.GetType().GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);
                    // Call close method
                    closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null);
                }
                if (addUnsentHeader)
                {
                    //Read the complete content from the file as byte[]
                    var content = File.ReadAllBytes(fileName);
                    //Reopen the file
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        var binaryWriter = new BinaryWriter(fileStream);
                        //Write the Unsent header to the file so the mail client knows this mail must be presented in "New message" mode
                        binaryWriter.Write(System.Text.Encoding.UTF8.GetBytes("X-Unsent: 1" + Environment.NewLine));
                        //Write the original message content to the file
                        binaryWriter.Write(content);
                    }
                }
            }
        }
    }
