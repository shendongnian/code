    public void PostImage(Stream stream)  
            {
                // get image from stream and implement your logic
                
                var headers = OperationContext.Current.IncomingMessageProperties["httpRequest"];
                // other parameters will be accessible here e.g image name etc
                var imgname = ((HttpRequestMessageProperty)headers).Headers["imgname"];
                
                
            }
