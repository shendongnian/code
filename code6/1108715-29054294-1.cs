    internal static async Task ForEachAsync(
        this IDbAsyncEnumerable source, Action<object> action, CancellationToken cancellationToken)
    {
        DebugCheck.NotNull(source);
        DebugCheck.NotNull(action);
        cancellationToken.ThrowIfCancellationRequested();
        using (var enumerator = source.GetAsyncEnumerator())
        {
            if (await enumerator.MoveNextAsync(cancellationToken).WithCurrentCulture())
            {
                Task<bool> moveNextTask;
                do
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var current = enumerator.Current;
                    moveNextTask = enumerator.MoveNextAsync(cancellationToken);
                    action(current);
                }
                while (await moveNextTask.WithCurrentCulture());
            }
        }
    }
