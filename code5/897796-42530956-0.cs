    interface IFoo
    {
        Task DoAsync(CancellationToken ct);
    }
    static class IFoo
    {
        public static Task DoAsync(this IFoo foo) => foo.DoAsync(CancellationToken.None);
    }
