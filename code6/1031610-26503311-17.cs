    public void Method() {
        // Operation One:
        var _ = TryCommitAsync();
        // Operation Two.
    }
    private async Task TryCommitAsync()
    {
        try
        {
            await CommitAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "Committing failed in the background: {0}", 
                ex.Message
            );
        }
    }
