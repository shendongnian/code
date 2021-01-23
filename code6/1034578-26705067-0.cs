     public static async void Transform(
    [ServiceBusTrigger("%InputQueue%")] string input,
    [ServiceBus("%OutputQueue%")] IAsyncCollector<string> output,
    TextWriter log)
        {            
            await output.AddAsync(input);
        }
