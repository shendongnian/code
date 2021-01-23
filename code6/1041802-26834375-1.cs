    async void NextArrow_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        if (!String.IsNullOrEmpty(TxtBox_mail.Text))
        {
           Uri myUri = new Uri("http://myUri");
           HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(myUri);
           myRequest.Method = "POST";
           myRequest.ContentType = "application/json";
           Stream postStream = await myRequest.GetRequestStreamAsync();
           HttpWebResponse response = await GetRequestStreamCallback(postStream, myRequest);
           // await GetResponsetStreamCallback(response) here...the
           // method wasn't shown in the original question, so I've left
           // out the particulars, as an exercise for the reader. :)
        }
    }
    async void GetRequestStreamCallback(Stream postStream, WebRequest myRequest)
    {
        byte[] byteArray = null;
        // Create the post data
        string mailToCheck = TxtBox_mail.Text.ToString();
        string postData = JsonConvert.SerializeObject(mailToCheck);
        byteArray = Encoding.UTF8.GetBytes(postData);
        // Add the post data to the web request
        postStream.Write(byteArray, 0, byteArray.Length);
        postStream.Close();
        // Start the web request
        return await myRequest.GetResponseAsync();
    }
