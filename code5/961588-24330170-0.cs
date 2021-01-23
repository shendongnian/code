    private async void Start_Click(object sender, EventArgs e)
    {
        await M1Async();
    }
    
    private static Task M1Async()
    {
        return M2Async();
    }
    
    private static Task M2Async()
    {
        return M3Async();
    }
    
    private static Task M3Async()
    {
        return M4Async();
    }
    
    private static Task M4Async()
    {
        return Task.Delay(1000);
    }
