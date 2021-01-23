    public static class WcfExt
    {
        public static Task<object> WorkAsync(this IService service, object arg)
        {
            return Task.Factory.FromAsync(
                 (asyncCallback, asyncState) =>
                     service.BeginWork(arg, asyncCallback, asyncState),
                 (asyncResult) =>
                     service.EndWork(asyncResult), null);
        }
    }
