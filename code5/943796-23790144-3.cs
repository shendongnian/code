    public static IObservable<string> ToNmeaSentence(
        this IObservable<char> characters
    )
    {
        return Observable.Create<string>(observer => {
            var sb = new StringBuilder();
            return characters.Subscribe(ch => {
                if (ch == '$' && sb.Length > 0)
                {
                    observer.OnNext(sb.ToString());
                    sb.Clear();
                }
                sb.Append(ch);
            });
        });
    }
