    private async void button1_Click(object sender, EventArgs e)
    {
        Console.WriteLine("0");
        await DoWorkAsync();
        Console.WriteLine("3");
    }
    private async Task DoWorkAsync()
    {
        Console.WriteLine("1");
        await Task.Run(()=>
            {
                // Do your db work here.
                Thread.Sleep(1500);
                
            });
        Console.WriteLine("2");
    }
