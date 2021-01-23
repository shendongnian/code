    public static class WcfExt
    {
        public static Task<int> AddAsync(this IAddTwoNumbers service, int a, int b)
        {
            return Task.Factory.FromAsync(
                 (asyncCallback, asyncState) =>
                     service.BeginAdd(a, b, asyncCallback, asyncState),
                 (asyncResult) =>
                     service.EndAdd(asyncResult);
        }
    }
