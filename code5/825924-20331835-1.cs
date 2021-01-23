    var service = new ObjectService(ConfigurationManager.AppSettings["AWSAccessKey"], ConfigurationManager.AppSettings["AWSSecretKey"], bucketName)
    
    public void StartUpload(string id, HttpPostedFileBase file)
        {
            var bucketName = CompanyProvider.CurrentCompanyId();
    
            
                service.Add(id);
    
                var caller = new AsyncMethodCaller(service.Upload);
                var result = caller.BeginInvoke(id, file, new AsyncCallback(CompleteUpload), caller);
            
        }
    
        public void CompleteUpload(IAsyncResult result)
        {
    
        var caller = (AsyncMethodCaller)result.AsyncState;
        var id = caller.EndInvoke(result);
        service.Close();
            service.Dispose();
        }
