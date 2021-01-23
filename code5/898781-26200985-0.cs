    using System;
    using System.Runtime.InteropServices;
    using CurlSharp;
    
    namespace SmtpMail
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct UploadContext
        {
            public int LinesRead;
        }
    
        internal class SmtpMail
        {
            private static void Main(string[] args)
            {
                try
                {
                    Curl.GlobalInit(CurlInitFlag.All);
    
                    using (var curl = new CurlEasy())
                    {
                        curl.Url = "smtp://localhost:25";
                        curl.Upload = true;
    
                        curl.ReadFunction = PayloadSource;
                        curl.ReadData = new UploadContext();
                        curl.SetOpt(CurlOption.MailFrom, "<from@example.com>");
                        using (var recipients = new CurlSlist())
                        {
                            recipients.Append("<to@example.net>");
                            recipients.Append("<cc@example.org>");
                            var s = recipients.Strings;
                            curl.SetOpt(CurlOption.MailRcpt, recipients.Handle);
    
                            curl.Perform();
                        }
                    }
    
                    Curl.GlobalCleanup();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
    
            private static byte[] GetBytes(string str)
            {
                var bytes = new byte[str.Length*sizeof (char)];
                Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
    
            private static int PayloadSource(byte[] buf, int size, int nmemb, object extradata)
            {
                var payloadText = new[]
                                  {
                                      "Date: Mon, 29 Nov 2010 21:54:29 +1100\r\n",
                                      "To: <to@example.net>\r\n",
                                      "From: <from@example.org> (Example User)\r\n",
                                      "Cc: <cc@example.org> (Another example User)\r\n",
                                      "Message-ID: <dcd7cb36-11db-487a-9f3a-e652a9458efd@rfcpedant.example.org>\r\n",
                                      "Subject: SMTP example message\r\n",
                                      "\r\n", /* empty line to divide headers from body, see RFC5322 */
                                      "The body of the message starts here.\r\n",
                                      "\r\n",
                                      "It could be a lot of lines, could be MIME encoded, whatever.\r\n",
                                      "Check RFC5322.\r\n"
                                  };
    
                var ctxUpload = (UploadContext) extradata;
    
                if ((ctxUpload.LinesRead >= 0) &&
                    (ctxUpload.LinesRead < payloadText.Length) &&
                    (size != 0) && (nmemb != 0) &&
                    ((size*nmemb) > 0))
                {
                    var line = payloadText[ctxUpload.LinesRead++];
                    var lineBuf = GetBytes(line);
                    Buffer.BlockCopy(lineBuf, 0, buf, 0, lineBuf.Length);
                    return lineBuf.Length;
                }
                return 0;
            }
        }
    }
