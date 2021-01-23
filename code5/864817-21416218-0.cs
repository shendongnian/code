    using ( var webClient = new WebClient() )
            {
                string content = webClient.DownloadString(url);
                if ( content.ToLower().Contains( xx.ToLower() ) )
                
            } 
