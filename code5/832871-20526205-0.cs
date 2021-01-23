            var proxyObj = new WebProxy("ipaddress:port");
            proxyObj.Credentials = CredentialCache.DefaultCredentials;
            using (var webClient = new WebClient())
            {
                webClient.Proxy = proxyObj;
                webClient.DownloadFile(remoteFileAddress, localFileAddress);
            }
