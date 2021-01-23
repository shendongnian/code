            WebClient webClient = new WebClient();
            webClient.UploadStringCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        //handle your error here
                    }
                    else
                    {
                        //post was successful, so do what you need to do here
                    }
                };
            webClient.UploadStringAsync(new Uri(yourUri), UriKind.Absolute), "POST", yourParameters);     
