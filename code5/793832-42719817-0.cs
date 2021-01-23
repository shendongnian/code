       #region ..... SOCKET MAIL .....
        private enum SMTPResponse : int
        {
            /// <summary>
            /// 220
            /// </summary>
            CONNECT_SUCCESS = 220,
            /// <summary>
            /// 235
            /// </summary>
            CRED_SUCCESS = 235,
            /// <summary>
            /// 250
            /// </summary>
            GENERIC_SUCCESS = 250,
            /// <summary>
            /// 334
            /// </summary>
            AUTH_SUCCESS = 334,
            /// <summary>
            /// 354
            /// </summary>
            DATA_SUCCESS = 354,
            /// <summary>
            /// 221
            /// </summary>
            QUIT_SUCCESS = 221
        }
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes, Base64FormattingOptions.None);
            return returnValue;
        }
        public bool SendFromSocket(MailMessage message)
        {
            var requestUri = new System.Uri("smtps://" +SmtpServer.Host +":"+SmtpServer.Port);
            Uri proxy = null;
			//This is magic code which does your job for the proxy 
            using (var web = new System.Net.WebClient())
            {                
                proxy = web.Proxy.GetProxy(requestUri);                
            }
         
            using (var s = new TcpClient(proxy.DnsSafeHost, proxy.Port  ))
            {               
                using (var stream = s.GetStream())
                using (var clearTextReader = new StreamReader(stream))
                using (var clearTextWriter = new StreamWriter(stream) { AutoFlush = true })
                using (var sslStream = new SslStream(stream))
                {
                    if (!Check_Response(clearTextReader, SMTPResponse.CONNECT_SUCCESS))
                    {
                        s.Close();
                        return false;
                    }
                    clearTextWriter.WriteLine("HELO");
                    if (!Check_Response(clearTextReader, SMTPResponse.GENERIC_SUCCESS))
                    {
                        s.Close();
                        return false;
                    }
                    clearTextWriter.WriteLine("STARTTLS");
                    if (!Check_Response(clearTextReader, SMTPResponse.CONNECT_SUCCESS))
                    {
                        s.Close();
                        return false;
                    }
                    sslStream.AuthenticateAsClient(SmtpServer.Host);
                    bool flag = sslStream.IsAuthenticated;
                    using (var reader = new StreamReader(sslStream))
                    using (var writer = new StreamWriter(sslStream) { AutoFlush = true })
                    {                       
                        writer.WriteLine(string.Format("EHLO {0}", SmtpServer.Host));
                        if (!Check_Response(reader, SMTPResponse.GENERIC_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        writer.WriteLine("AUTH LOGIN");
                        if (!Check_Response(reader, SMTPResponse.AUTH_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        writer.WriteLine(EncodeTo64(SenderId));
                        if (!Check_Response(reader, SMTPResponse.AUTH_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        writer.WriteLine(EncodeTo64(Password));
                        if (!Check_Response(reader, SMTPResponse.CRED_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        writer.WriteLine("MAIL FROM: <{0}>", message.From);
                        if (!Check_Response(reader, SMTPResponse.GENERIC_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        foreach (MailAddress To in message.To)
                        {
                            writer.WriteLine("RCPT TO: <{0}>", To.Address);
                            if (!Check_Response(reader, SMTPResponse.GENERIC_SUCCESS))
                            {
                                s.Close();
                                return false;
                            }
                        }
                        if (message.CC != null)
                        {
                            foreach (MailAddress cc in message.CC)
                            {
                                writer.WriteLine(string.Format("RCPT TO: <{0}>", cc.Address));
                                if (!Check_Response(reader, SMTPResponse.GENERIC_SUCCESS))
                                {
                                    s.Close();
                                    return false;
                                }
                            }
                        }
                        StringBuilder Header = new StringBuilder();
                        Header.Append("From: " + message.From + "\r\n");
                        Header.Append("To: ");
                        for (int i = 0; i < message.To.Count; i++)
                        {
                            Header.Append(i > 0 ? "," : "");
                            Header.Append(message.To[i].Address);
                        }
                        Header.Append("\r\n");
                        if (message.CC != null)
                        {
                            Header.Append("Cc: ");
                            for (int i = 0; i < message.CC.Count; i++)
                            {
                                Header.Append(i > 0 ? "," : "");
                                Header.Append(message.CC[i].Address);
                            }
                            Header.Append("\r\n");
                        }
                        Header.Append("Date: ");
                        Header.Append(DateTime.Now.ToString("ddd, d M y H:m:s z"));
                        Header.Append("\r\n");
                        Header.Append("Subject: " + message.Subject + "\r\n");
                        Header.Append("X-Mailer: SMTPDirect v1\r\n");
                        string MsgBody = message.Body;
                        if (!MsgBody.EndsWith("\r\n"))
                            MsgBody += "\r\n";
                        if (message.Attachments.Count > 0)
                        {
                            Header.Append("MIME-Version: 1.0\r\n");
                            Header.Append("Content-Type: multipart/mixed; boundary=unique-boundary-1\r\n");
                            Header.Append("\r\n");
                            Header.Append("This is a multi-part message in MIME format.\r\n");
                            StringBuilder sb = new StringBuilder();
                            sb.Append("--unique-boundary-1\r\n");
                            sb.Append("Content-Type: text/plain\r\n");
                            sb.Append("Content-Transfer-Encoding: 7Bit\r\n");
                            sb.Append("\r\n");
                            sb.Append(MsgBody + "\r\n");
                            sb.Append("\r\n");
                            foreach (object o in message.Attachments)
                            {
                                Attachment a = o as Attachment;
                                byte[] binaryData;
                                if (a != null)
                                {
                                    //FileInfo f = new FileInfo(a.);
                                    sb.Append("--unique-boundary-1\r\n");
                                    sb.Append("Content-Type: application/octet-stream; file=" + a.Name + "\r\n");
                                    sb.Append("Content-Transfer-Encoding: base64\r\n");
                                    sb.Append("Content-Disposition: attachment; filename=" + a.Name + "\r\n");
                                    sb.Append("\r\n");
                                    Stream fs = a.ContentStream;
                                    binaryData = new Byte[fs.Length];
                                    long bytesRead = fs.Read(binaryData, 0, (int)fs.Length);
                                    fs.Close();
                                    string base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
                                    for (int i = 0; i < base64String.Length; )
                                    {
                                        int nextchunk = 100;
                                        if (base64String.Length - (i + nextchunk) < 0)
                                            nextchunk = base64String.Length - i;
                                        sb.Append(base64String.Substring(i, nextchunk));
                                        sb.Append("\r\n");
                                        i += nextchunk;
                                    }
                                    sb.Append("\r\n");
                                }
                            }
                            MsgBody = sb.ToString();
                        }
                        writer.WriteLine("DATA\r\n");
                        if (!Check_Response(reader, SMTPResponse.DATA_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        Header.Append("\r\n");
                        Header.Append(MsgBody);
                        Header.Append(".\r\n");
                        Header.Append("\r\n");
                        Header.Append("\r\n");
                        writer.WriteLine(Header.ToString());
                        if (!Check_Response(reader, SMTPResponse.GENERIC_SUCCESS))
                        {
                            s.Close();
                            return false;
                        }
                        writer.WriteLine("QUIT\r\n");
                        Check_Response(reader, SMTPResponse.QUIT_SUCCESS);
                        s.Close();
                        return true;
                    }
                }
            }
        }
        private static bool Check_Response(StreamReader netStream, SMTPResponse response_expected)
        {
           
            int response;
            int read = 0;
            StringBuilder sResponse = new StringBuilder();
            do
            {
                char[] buffer = new char[1024];                
                read = netStream.Read(buffer, 0, buffer.Length);
                sResponse.Append(buffer);                
            }
            while (read == 1024);
            response = Convert.ToInt32(sResponse.ToString().Substring(0, 3));
            
            if (response != (int)response_expected)
                return false;
            return true;
        }
        #endregion ..... SOCKET MAIL .....
