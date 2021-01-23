csharp
/// Yes this looks like a correct async method handler but the compiler is
/// matching the connection.On<int>(string methodName, Action<int> method)
/// overload and we get the "async-void" behaviour discussed above
connection.On<int>(nameof(AsyncHandler), async (i) => await AsyncHandler(i)));
/// This method runs interleaved, "multi-threaded" since the SignalR client is just
/// "fire and forgetting" it.
async Task AsyncHandler(int value) {
    Console.WriteLine($"Async Starting {value}");
    await Task.Delay(1000).ConfigureAwait(false);
    Console.WriteLine($"Async Ending {value}");
}
The good news is, we can attach asynchronous method handlers and have the client call them one at a time, sequentially, without interleaving, without blocking any threads.
We utilize the following override found in the latest version of the SignalR client.
IDisposable On(this HubConnection hubConnection, string methodName, Type[] parameterTypes, Func<object[], Task> handler)
Here's the code that achieves it. Woefully, the code you write to attach the handler is a bit obtuse, but here it is: 
csharp
/// Properly attaching an async method handler
connection.On(nameof(AsyncHandler), new[] { typeof(int) }, AsyncHandler);
/// Now the client waits for one handler to finish before calling the next.
/// We are back to the expected behaviour of having the client call the handlers
/// one at a time, waiting for each to finish before starting the next.
async Task AsyncHandler(object[] values) {
    var value = values[0];
    Console.WriteLine($"Async Starting {value}");
    await Task.Delay(1000).ConfigureAwait(false);
    Console.WriteLine($"Async Ending {value}");
}
Of course, now that you have the knowledge that lets you get expected behaviour from the SignalR client, you can leverage it to allow some calls to be run in parallel with others if you want.
