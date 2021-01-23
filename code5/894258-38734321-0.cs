     var handler = new ModernHttpClient.NativeMessageHandler()
            {
                UseProxy = true,
            }; ;
            
            handler.ClientCertificateOptions = ClientCertificateOption.Automatic;
            handler.PreAuthenticate = true;
            HttpClient client = new HttpClient(handler);
