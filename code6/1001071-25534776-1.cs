    var pingTasks = addresses.Select(address =>
    {
        return new Ping().SendTaskAsync(address);
    });
    var replies = await Task.WhenAll(pingTasks);
    StringBuilder pingResultBuilder = new StringBuilder();
    foreach (var pingReply in replies)
    {
        pingResultBuilder.Append(pingReply.Address);
        pingResultBuilder.Append("    ");
        pingResultBuilder.Append(pingReply.Reply.Status);
        pingResultBuilder.Append("    ");
        pingResultBuilder.Append(pingReply.Reply.RoundtripTime.ToString());
        pingResultBuilder.AppendLine();
    }
    Console.WriteLine(pingResultBuilder.ToString());
