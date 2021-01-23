            XmlWriter writer;
            StringBuilder sb = new StringBuilder();
            writer = XmlWriter.Create(sb);
            writer.WriteStartElement("serv_request");
            writer.WriteStartElement("head");
            writer.WriteStartElement("securityContext");
            writer.WriteStartElement("account");
            writer.WriteString("MyAccountName");
            writer.WriteEndElement();
            writer.WriteStartElement("key");
            writer.WriteString("MyKey");
            writer.WriteEndElement(); //closes Key Element
            writer.WriteEndElement(); // closes securityContent
            writer.WriteEndElement(); //closes head
            writer.WriteStartElement("body");
            writer.WriteStartElement("username");
            writer.WriteString("MyUserName");
            writer.WriteEndElement(); // closes username
            writer.WriteEndElement(); //closes body
            writer.WriteEndElement(); //closes serv_request
            writer.Close();
    
            NameValueCollection nvc = new NameValueCollection();           
            nvc.Add("xml", sb.ToString());          
            WebClient client = new WebClient();
            byte[] byteresponse = client.UploadValues(url, nvc);
            string xmlresponse = client.Encoding.GetString(byteresponse);
