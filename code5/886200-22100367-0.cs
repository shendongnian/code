            HttpWebResponse statusResponse = null;
            string response = "";
            StringBuilder sbUrl = new StringBuilder(dwrq.data_url);   // hardcode to variable "rest_url" for testing.
            HttpWebRequest omniRequest = (HttpWebRequest)WebRequest.Create(sbUrl.ToString());
            string timecreated = generateTimestamp();
            string nonce = generateNonce();
            string digest = getBase64Digest(nonce + timecreated + secret);
            nonce = base64Encode(nonce);
            omniRequest.Headers.Add("X-WSSE: UsernameToken Username=\"" + username + "\", PasswordDigest=\"" + digest + "\", Nonce=\"" + nonce + "\", Created=\"" + timecreated + "\"");
            omniRequest.Method = "GET";  // Switched from POST as GET is the right HTTP verb in this case
            try
            {
                statusResponse = (HttpWebResponse)omniRequest.GetResponse();
                using (Stream receiveStream = statusResponse.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        response = readStream.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Console.WriteLine("Response is a TAB delimeted CSV structure. Printing to screen.");
            Console.WriteLine(response);
            Console.WriteLine("Ending REST...");
            Console.WriteLine("Ending ExportRequestSegmentedData...");
