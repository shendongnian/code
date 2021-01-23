    System.Net.WebClient Client = new System.Net.WebClient();
    Client.Headers.Add("Content-Type", "binary/octet-stream");
    byte[] result = Client.UploadFile("localhost/FolderName/upload.php", "POST", path);
    string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
    
