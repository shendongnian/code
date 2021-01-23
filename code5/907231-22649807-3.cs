    public async Task BackgroundThreadProc()
    {
        for (var i = 0; i < 100; i++)
        {
            await Task.Delay(1000);
            
            // create object
            var animal = new Animal { Name = "test" + i };
            log(animal);
        }
    }
