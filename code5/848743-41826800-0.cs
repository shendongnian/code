<Code>
    watcher.Error += Watcher_Error;
    ...
    private void Watcher_Error(object sender, ErrorEventArgs e)
    {
        Debug.WriteLine("Watcher_Error: " + e.GetException().Message);
    }
</Code>
