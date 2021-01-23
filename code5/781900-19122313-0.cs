    public static class MyLveExtensionAsync
    {
        public static Task<LiveOperationResult> GetResponseAsync(this LiveConnectClient client, string param)
            {
                TaskCompletionSource<LiveOperationResult> tcs=new TaskCompletionSource<LiveOperationResult>();
                EventHandler<LiveOperationCompletedEventArgs> handler = null;
                handler=(sender, arg) =>
                {
                    client.GetCompleted -= handler;
                    if (arg.Cancelled)
                    {
                        tcs.TrySetCanceled();
                    }
                    else if (arg.Error != null)
                    {
                        tcs.TrySetException(arg.Error);
                    }
                    else
                    {
                        LiveOperationResult result =new LiveOperationResult(arg.Result,arg.RawResult);
                        tcs.TrySetResult(result);
                    }
                };
                client.GetCompleted += handler;
                 client.GetAsync(param);
                return tcs.Task;
            }
    
    }
