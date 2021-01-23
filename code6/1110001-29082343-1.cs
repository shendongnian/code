    class Program
    {
        static CertificateRequest DeserializeRequest(string content)
        {
            CertificateRequest request = null;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + content);
                ms.Write(data, 0, data.Length);
                ms.Position = 0;
                XmlSerializer xs = new XmlSerializer(typeof(CertificateRequest));
                request = xs.Deserialize(ms) as CertificateRequest;
            }
            return request;
        }
        static void Main(string[] args)
        {
            string xmlAsString = @"<CertificateRequest><ReturnCode>0</ReturnCode><Payload content_type=""application/pdf"" embedded=""base64"">SGVsbG8gV29ybGQ=</Payload></CertificateRequest>";
            CertificateRequest request = DeserializeRequest(xmlAsString);
            Console.WriteLine(request.Payload.Value);
            Console.WriteLine(request.Payload.DecodedValue);
            Console.ReadLine();
        }
    }
