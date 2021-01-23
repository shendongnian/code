    public static class Extensions
    {
        public static System.Threading.Tasks.Task<System.IO.Stream> GetRequestStreamAsync(this System.Net.WebRequest wr)
        {
            if (wr.ContentLength < 0)
            {
                throw new InvalidOperationException("The ContentLength property of the WebRequest must first be set to the length of the content to be written to the stream.");
            }
            var tcs = new System.Threading.Tasks.TaskCompletionSource<System.IO.Stream>();
            wr.BeginGetRequestStream((result) =>
            {
                var source = (System.Net.WebRequest)result.AsyncState;
                tcs.TrySetResult(source.EndGetRequestStream(result));
            }, wr);
            return tcs.Task;
        }
        public static System.Threading.Tasks.Task<System.Net.WebResponse> GetResponseAsync(this System.Net.WebRequest wr)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<System.Net.WebResponse>();
            wr.BeginGetResponse((result) =>
            {
                var source = (System.Net.WebRequest)result.AsyncState;
                tcs.TrySetResult(source.EndGetResponse(result));
            }, wr);
            return tcs.Task;
        }
    }
