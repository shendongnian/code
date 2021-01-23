    private async void button1_Click(object sender, EventArgs e)
    {
       await DoSomethingAsync();
    }
    
    private async Task DoSomethingAsync()
    {
        await Task.Delay(3000); // simulate job
    
        MessageBox.Show("DoSomethingAsync is done");
    
        await DoSomething2Async();
    }
    
    private async Task DoSomething2Async()
    {
        await Task.Delay(3000); // simulate job
    
        MessageBox.Show("DoSomething2Async is done");
    }
