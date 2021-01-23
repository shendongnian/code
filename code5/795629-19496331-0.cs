    class WrapperAroundNativeCode
    {
        public async Task<string> RequestData(string inputData)
        {
            var completionSource = new TaskCompletionSource<string>();
            Native.RegisterCallback(s => completionSource.SetResult(s));
            Native.RequestData(inputData);
            return completionSource.Task;
        }
    }
