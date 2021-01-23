    System.Net.WebClient wc = new System.Net.WebClient();
    wc.Headers.Add("Content-Type", String.Format("multipart/form-data; boundary=\"{0}\"", multipartFormBoundary));
    wc.UseDefaultCredentials = true;
    
    try
    {
    	var wcResponse = wc.UploadData(BaseUrl + "api/job/PostJobEmailNote", byteArray);
    }
    catch(Exception e)
    {
    	// response status code was not in 200's 
    }
