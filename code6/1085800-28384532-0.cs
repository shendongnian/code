        SendToHikVision("admin", "12345", "192.0.0.64", "*The Port You're Using");
        void SendToHikVision(string UserName, string Password, string IP, string Port)
        {
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://" + IP + ":" + Port + "/Network/interfaces/1/");
                wr.Accept = "*/*";
                wr.Method = "PUT";
                wr.ReadWriteTimeout = 5000;
                wr.Credentials = new NetworkCredential(UserName, Password);
                byte[] pBytes = GetDHCPPost();
                wr.ContentLength = pBytes.Length;
                using (Stream DS = wr.GetRequestStream())
                {
                    DS.Write(pBytes, 0, pBytes.Length);
                    DS.Close();
                }
                wr.BeginGetResponse(r => { var reponse = wr.EndGetResponse(r); }, null);
            }
            catch { }
        }
        byte[] GetDHCPPost()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<IPAddress version=\"1.0\" xmlns=\"http://www.hikvision.com/ver10/XMLSchema\">");
            sb.AppendLine("<ipVersion>v4</ipVersion>");
            sb.AppendLine("<addressingType>dynamic</addressingType>");
            sb.AppendLine("<ipAddress>172.2.62.49</ipAddress>");
            sb.AppendLine("<subnetMask>255.255.255.0</subnetMask>");
            sb.AppendLine("<DefaultGateway>");
            sb.AppendLine("<ipAddress>172.2.62.1</ipAddress>");
            sb.AppendLine("</DefaultGateway>");
            sb.AppendLine("<PrimaryDNS>");
            sb.AppendLine("<ipAddress>0.0.0.0</ipAddress>");
            sb.AppendLine("</PrimaryDNS>");
            sb.AppendLine("</IPAddress> ");
            return Encoding.ASCII.GetBytes(sb.ToString());
        }
