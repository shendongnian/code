    public static class MakeItAsync
    {
        static public void TrySetAsync<T>(this TaskCompletionSource<T> source, T result)
        {
            var continuation = typeof(Task).GetField("m_continuationObject", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            var continuations = (List<object>)continuation.GetValue(source.Task);
            foreach (object c in continuations)
            {
                var option = c.GetType().GetField("m_options", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                var options = (TaskContinuationOptions)option.GetValue(c);
                options &= ~TaskContinuationOptions.ExecuteSynchronously;
                option.SetValue(c, options);
            }
            source.TrySetResult(result);
        }        
    }
