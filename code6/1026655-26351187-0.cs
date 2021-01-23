    public string DownloadStringAsync()
        {
            return "Test data";
        }
        public async Task<string> ReceiveStringAsync()
        {
            return await Task<string>.Run(() =>
            {
                //Method to download your data
                return DownloadStringAsync();
            });
        }
