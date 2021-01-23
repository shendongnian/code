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
/* Example output:
Async Starting 0
Async Starting 1
Async Starting 2
Async Starting 3
Async Starting 4
Async Starting 5
Async Starting 6
Async Starting 7
Async Starting 8
Async Ending 2
Async Ending 3
Async Ending 0
Async Ending 1
Async Ending 8
Async Ending 7
*/
If you're using ASP.NET Core, we can attach asynchronous method handlers and have the client call them one at a time, sequentially, without interleaving, without blocking any threads.
We utilize the [following override][1] introduced in SignalR for ASP.NET Core.
    IDisposable On(this HubConnection hubConnection, string methodName, Type[] parameterTypes,
                    Func<object[], Task> handler)
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
/* Example output
Async Starting 0
Async Ending 0
Async Starting 1
Async Ending 1
Async Starting 2
Async Ending 2
Async Starting 3
Async Ending 3
Async Starting 4
Async Ending 4
Async Starting 5
Async Ending 5
Async Starting 6
Async Ending 6
Async Starting 7
Async Ending 7
*/
Of course, now you know how to achieve either kind of client behaviour depending on your requirements. If you choose to use the async-void behaviour, it would be best to comment this really really well so you don't trap other programmers, and make sure you don't throw unhandled task exceptions.
  [1]: https://docs.microsoft.com/en-ca/dotnet/api/microsoft.aspnetcore.signalr.client.hubconnection.on
