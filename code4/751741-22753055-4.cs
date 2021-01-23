    async Task TestAsync()
    {
        using(var client = new WcfAPM.ServiceClient())
        using (var scope = new FlowingOperationContextScope(client.InnerChannel))
        {
            await client.SomeMethodAsync(1).ContinueOnScope(scope);
            await client.AnotherMethodAsync(2).ContinueOnScope(scope);
        }
    }
