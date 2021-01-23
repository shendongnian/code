    private void Form1_Shown(object sender, EventArgs e)
    {
         WebClient webClient = new WebClient();
         webClient.Encoding = Encoding.UTF8;
         webClient.Headers.Add(@"Content-Type: application/json; charset=utf-8");
         webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
         Task task = new Task(() => { webClient.UploadDataAsync(new Uri("your uri"),"POST",json); });
         task.Start();
    }
