    public static class Extensions
    {
        public static System.Threading.Tasks.Task<System.IO.Stream> GetRequestStreamAsync(this System.Net.HttpWebRequest wr)
        {
            if (wr.ContentLength < 0)
            {
                throw new InvalidOperationException("The ContentLength property of the HttpWebRequest must first be set to the length of the content to be written to the stream.");
            }
            var tcs = new System.Threading.Tasks.TaskCompletionSource<System.IO.Stream>();
            wr.BeginGetRequestStream((result) =>
            {
                var source = (System.Net.HttpWebRequest)result.AsyncState;
                tcs.TrySetResult(source.EndGetRequestStream(result));
            }, wr);
            return tcs.Task;
        }
    }
