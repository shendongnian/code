        public static void SlackSendFile(string token, string channelId, string filepath)
        {
            FileStream str = File.OpenRead(filepath);
            byte[] fBytes = new byte[str.Length];
            str.Read(fBytes, 0, fBytes.Length);
            str.Close();
            var webClient = new WebClient();
            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
            var fileData = webClient.Encoding.GetString(fBytes);
            var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, "Testing.txt", "multipart/form-data", fileData);
            var nfile = webClient.Encoding.GetBytes(package);
            var encodedfile = System.Text.Encoding.ASCII.GetString(nfile);
            string url = "https://slack.com/api/files.upload?token=" + token + "&content=" + encodedfile + "&channels=" + channelId + "";
            byte[] resp = webClient.UploadData(url, "POST", nfile);
            var k = System.Text.Encoding.Default.GetString(resp);
            Console.WriteLine(k);
        }
