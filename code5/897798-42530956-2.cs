    interface IFoo
    {
        Task DoAsync(CancellationToken ct);
    }
    static class Foo
    {
        public static Task DoAsync(this IFoo foo) => foo.DoAsync(CancellationToken.None);
    }
