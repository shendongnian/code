        private SemaphoreSlim maxThread = new  SemaphoreSlim(3);
        private async void btnDoWebRequest_Click(object  sender, EventArgs e)
        {
            btnDoWebRequest.Enabled = false;
            await DoWebRequest();
            btnDoWebRequest.Enabled = true;
         }
         private async Task DoWebRequest()
         {
             List<requestInfo> requestInfoList = new List<requestInfo>();
             var requestInfoList =  dataRequestInfo.Rows.Select(x => x.Tag).Cast<requestInfo>();
            var tasks = requestInfoList.Select(async I => 
            {
                 await maxThread.WaitAsync();
                 try
                 {
                     await Global.webRequestWork(i);
                 }
                 finally
                 {
                     maxThread.Release();
                 }
           });
        
           await Task.WhenAll(tasks);
