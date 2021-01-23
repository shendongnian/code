    public String UploadImage(string image) 
        { 
            WebClient w = new WebClient();
            w.UploadProgressChanged += (s, e) =>
            {
                myProgressBar.Value = e.ProgressPercentage;
            };
            w.UploadValuesCompleted += (s, e) =>
            {
                myProgressBar.Value = 100;
            };
            w.Headers.Add("Authorization", "Client-ID " + ClientId);
            System.Collections.Specialized.NameValueCollection Keys = new System.Collections.Specialized.NameValueCollection(); 
            try 
            { 
                Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image))); 
                byte[] responseArray = await w.UploadValuesAsync("https://api.imgur.com/3/image", Keys);
    
                dynamic result = Encoding.ASCII.GetString(responseArray); System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("link\":\"(.*?)\""); 
                System.Text.RegularExpressions.Match match = reg.Match(result); 
                string url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");
                textBox1.Text = url;
                return url; 
            } catch (Exception s) 
            { 
                MessageBox.Show("Something went wrong. " + s.Message); 
                    return "Failed!"; 
            } 
        }
  
