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
    
		    String result = e.Result;
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("link\":\"(.*?)\""); 
                System.Text.RegularExpressions.Match match = reg.Match(result); 
                string url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");
                textBox1.Text = url;
            };
            w.Headers.Add("Authorization", "Client-ID " + ClientId);
            System.Collections.Specialized.NameValueCollection Keys = new System.Collections.Specialized.NameValueCollection(); 
            try 
            { 
                Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image))); 
                w.UploadValuesAsync("https://api.imgur.com/3/image", Keys);
                return "Uploading..";
            } catch (Exception s) 
            { 
                MessageBox.Show("Something went wrong. " + s.Message); 
                    return "Failed!"; 
            } 
        }
  
