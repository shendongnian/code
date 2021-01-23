     protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //sometesting for clear process
            IDictionary<string, string> m_OriginalHeaders;
            IDictionary<string, string> m_OriginalContentHeaders;
            
             //sometesting for clear process
             // and if none of them response...
            
            EllipticCurveDiffieHellman.Security.ClientIV = m_SecondPart.First();
            
            
            string encryptedMessage = string.Empty;
            string jsonDecryptedMessage = string.Empty;
            m_OriginalContentHeaders = new Dictionary<string, string>();
            byte[] jsonBytes;
            foreach (var header in request.Content.Headers)
            {
                if (!header.Key.Equals("Content-Length"))
                {
                    m_OriginalContentHeaders.Add(header.Key, header.Value.First());
                }
            } 
            Stream newStream = new MemoryStream();
            StreamReader streamReader = new StreamReader(request.Content.ReadAsStreamAsync().Result);               
            encryptedMessage = streamReader.ReadToEnd();
            jsonDecryptedMessage = EllipticCurveDiffieHellman.Security.Decryption(encryptedMessage);
    StreamWriter streamWriter = new StreamWriter(newStream);
                streamWriter.Write(jsonDecryptedMessage);
                streamWriter.Flush();
                newStream.Seek(0, SeekOrigin.Begin);
    
                request.Content = new StreamContent(newStream);
                           
                foreach (var header in m_OriginalContentHeaders)
                {
                    request.Content.Headers.Add(header.Key, header.Value);
                }
                           
                return base.SendAsync(request, cancellationToken);
            }
        }
