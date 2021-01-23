        private async Task<string> DoRequest(string Type, string Device, string Version, string Os)
        {
            //Declarations of Variables
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContinueTimeout = 4000;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            //Add headers to request
            request.Headers["Type"] = Type;
            request.Headers["Device"] = Device;
            request.Headers["Version"] = Version;
            request.Headers["Os"] = Os;
            request.Headers["Cache-Control"] = "no-cache";
            request.Headers["Pragma"] = "no-cache";
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //To obtain response body
                    using (Stream streamResponse = response.GetResponseStream())
                    {
                        using (StreamReader streamRead = new StreamReader(streamResponse, Encoding.UTF8))
                        {
                            result = streamRead.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
