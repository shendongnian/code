    string compressedData;
    using (MemoryStream ms = new MemoryStream())
    {
        using (GZipStream gz = new GZipStream(CompressionMode.Compress, true))
        {
            using (XmlWriter writer = XmlWriter.Create(gz))
            {
                writer.WriteStartElement("Claim");
                // write claim stuff here
                writer.WriteEndElement();
            }
        }
        // now base64 encode the memory stream buffer
        byte[] buff = ms.GetBuffer();
        compressedData = Convert.ToBase64String(buff, 0, buff.Length);
    }
