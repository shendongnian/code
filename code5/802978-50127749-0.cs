        private static byte[] DownloadFile(string url)
        {
            byte[] result = null;
            using (WebClient webClient = new WebClient())
            {
                result = webClient.DownloadData(url);
            }
            return result;
        }
