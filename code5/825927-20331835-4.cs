    using (var service = new ObjectService(ConfigurationManager.AppSettings["AWSAccessKey"], ConfigurationManager.AppSettings["AWSSecretKey"], bucketName))
            {
                service.Add(id);
    
                var caller = new AsyncMethodCaller(service.Upload);
                var result = caller.BeginInvoke(id, file, new AsyncCallback(CompleteUpload), caller);
            }  
