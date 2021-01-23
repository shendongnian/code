    public static Task<Guid> GetAMSessionGUIDAsync()
    {
        Debug.WriteLine("setting up client");
        AMClient client = new AMClient();
        TaskCompletionSource<Guid> completionSource = new TaskCompletionSource<Guid>();
        client.GetSessionCompleted += (sender, e) =>
        {
            Debug.WriteLine("session completed " + session);
            completionSource.SetResult(e.Result.session_ID);
        };
        client.GetSessionAsync();
        return completionSource.Task;
    }
