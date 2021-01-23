        SecureWebClient wc = new SecureWebClient();
		wc.Headers.Add("Cookie: " + cookies);
		wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
		byte[] result = wc.UploadData("<URL>", "POST", System.Text.Encoding.UTF8.GetBytes(postData));
		File.WriteAllBytes(@"C:\Temp\<FileName>", result);
		wc.Dispose();
    
