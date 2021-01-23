    class WrapperAroundNativeCode
    {
        public async Task<string> RequestData(string inputData)
        {
            var completionSource = new TaskCompletionSource<string>();
            var result = Native.RegisterCallback(s => completionSource.SetResult(s));
            if(result == -1)
            {
                completionSource.SetException(new SomeException("Failed to set callback"));
                return completionSource.Task;
            }
            result = Native.RequestData(inputData);
            if(result == -1)
                completionSource.SetException(new SomeException("Failed to request data"));
            return completionSource.Task;
        }
    }
