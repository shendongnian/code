    public static class RestClientExtensions
    {
        public static Task<IRestResponse> ExecuteTask(this IRestClient client, RestRequest request)
        {
            var TaskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, (response, asyncHandle) =>
            {
                if (response.ResponseStatus == ResponseStatus.Error)
                    TaskCompletionSource.SetException(response.ErrorException);
                else
                    TaskCompletionSource.SetResult(response);
            });
            return TaskCompletionSource.Task;
        }
    }
