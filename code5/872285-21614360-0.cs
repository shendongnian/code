                string msg = string.Format("{0}{1}{2}", nonce, clientId, apiKey);
                var signature = ByteArrayToString(SignHMACSHA256(apiSecret, StrinToByteArray(msg))).ToUpper();
                var path = "https://www.bitstamp.net/api/user_transactions/";
    
                using (WebClient client = new WebClient())
                {
    
                    byte[] response = client.UploadValues(path, new NameValueCollection()
                    {
                        { "key", apiKey },
                        { "signature", signature },
                        { "nonce", nonce.ToString()},
    
                    });
    
                    var str = System.Text.Encoding.Default.GetString(response);
                }
