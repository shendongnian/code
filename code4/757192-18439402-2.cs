    public static Task<Storyboard> BeginAsync(this Storyboard sb)
    {
       var tcs = new TaskCompletionSource<Storyboard>();
       sb.Completed += (s, a) => tcs.TrySetResult(sb);
       sb.Begin();
       return tcs.Task;
    }
