    using (System.Net.WebClient Client = new System.Net.WebClient()) 
    {
        Client.Headers.Add("Content-Type", "binary/octet-stream");
        byte[] result = Client.UploadFile("http://192.168.0.52/mipzy/html/application.php", "POST", file);
        string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length); 
        MessageBox.Show(s);
    }
