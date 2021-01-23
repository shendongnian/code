    using (CustomWebClient client = new CustomWebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + base64String;
                responseData = client.DownloadData(baseUri);
            }
