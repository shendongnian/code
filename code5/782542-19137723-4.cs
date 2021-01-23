    ...
    var request = WebRequest.Create(path) as HttpWebRequest;
            request.AllowReadStreamBuffering = true;
            request.BeginGetResponse(result =>
            {
                
                try
                {
                    
                    Stream imageStream = request.EndGetResponse(result).GetResponseStream();
                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    {
                    if (path!=SafePath){
                      //Item has been recycled
                      return;
                    }
                     ....
