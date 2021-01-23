    var activex = (SHDocVw.WebBrowser_V1)this.webBrowser.ActiveXInstance;
     
    activex.NewWindow += delegate(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
    {
        Processed = true;
    
        object flags = Flags;
        object targetFrame = Type.Missing;
        object postData = PostData != null ? PostData : Type.Missing;
        object headers = !String.IsNullOrEmpty(Headers) ? Headers.ToString() : Type.Missing;
    
        //SynchronizationContext.Current.Post(delegate
        //{
        //    activex.Navigate(URL, ref flags, ref targetFrame, ref postData, ref headers);
        //}, null);
    
        activex.Navigate(URL, ref flags, ref targetFrame, ref postData, ref headers);
    };
