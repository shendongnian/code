    ...
    var _block = new ActionBlock<bool>(async b =>
                    {
                        Console.WriteLine("start");
                        await Task.Delay(5000);
                        Console.WriteLine("end");
                    });
    ...
    
    
    async void button_Click(object sender, RoutedEventArgs e)
    {
        await _block.SendAsync(true);
    }
