        public async Task<byte[]> DownloadData(string url)
        {
            TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
            HttpWebRequest request = WebRequest.CreateHttp(url);
            using (HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync()))
            using (Stream stream = response.GetResponseStream())
            using (MemoryStream ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                tcs.SetResult(ms.ToArray());
                return await tcs.Task;
            }
        }
