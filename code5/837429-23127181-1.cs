        public Task<T> GetAsync<T>(string key)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            try
            {
                string dataStoreView = this.httpClient.Get(uri).ResponseBody;
                tcs.SetResult(Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<T>(dataStoreView));
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
