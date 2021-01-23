    public String UploadImage(string image) 
        { 
            WebClient w = new WebClient();
            w.UploadProgressChanged += (s, e) =>
            {
                myProgressBar.Maximum = (int)e.TotalBytesToSend;
                myProgressBar.Value = (int)e.BytesSent;
            };
            w.UploadValuesCompleted += new UploadValuesCompletedEventHandler(UploadComplete);
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
    public void UploadComplete(Object sender, UploadValuesCompletedEventArgs e)
    {
        myProgressBar.Value = 100;
    
        byte[] responseArray = e.Result;
        dynamic result = Encoding.ASCII.GetString(responseArray); 
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("link\":\"(.*?)\""); 
        System.Text.RegularExpressions.Match match = reg.Match(result); 
        string url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");
        textBox1.Text = url;
    }
  
