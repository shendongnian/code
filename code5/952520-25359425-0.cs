        private void GoogleSpeechToText()
        {
            string uri = "https://www.google.com/speech-api/full-duplex/v1/up?output=json&key=AIzaSyBOti4mM-6x9WDnZIjIeyEU21OpBXqWBgw&pair=" + GenerateUnique(16) + "&lang=en-US&pFilter=2&maxAlternatives=10&client=chromium";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Timeout = 10000;
            request.Method = "POST";
            request.Host = "www.google.com";            
            request.KeepAlive = true;
            request.SendChunked = true;
            request.ContentType = "audio/x-flac; rate=16000";
            request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-GB,en-US;q=0.8,en;q=0.6");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36";
            
            string path = @"C:\TestFolder\test_audio.flac";     
            FileInfo fInfo = new FileInfo(path);
            var numBytes = fInfo.Length;
            byte[] data;
            using (FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                data = new Byte[numBytes];
                fStream.Read(data, 0, (int) numBytes);
                fStream.Close();
            }
            using (Stream reqStream = request.GetRequestStream())
                reqStream.Write(data, 0, data.Length);
                        
            try
            {
                WebResponse response = request.GetResponse();
                Stream respStream = response.GetResponseStream();
                
                if(response.ContentType == "application/json; charset=utf-8")
                {                    
                    using (var sr = new StreamReader(respStream))
                    {
                        var res = sr.ReadToEnd();
                        textBox1.Text = res;                        
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK); }            
        }
        private string GenerateUnique(int length)
        {
            string[] LETTERS = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] DIGITS = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string buffer = "";
            Random random = new Random();
            for(int i = 0; i < length; i++)
            {                
                int rnd = random.Next(2);
                if (rnd == 1)
                    buffer += LETTERS[random.Next(LETTERS.Length)];
                else
                    buffer += DIGITS[random.Next(DIGITS.Length)];
            }
            return buffer;
        }
        
