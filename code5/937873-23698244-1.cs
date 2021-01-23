    var incomingMessages = Observable.FromEventPattern<MessageReceivedEventArgs>(
        h => _networkClient.MessageReceivedEvent += h,
        h => _networkClient.MessageReceivedEvent -= h)
    .Select(x => x.EventArgs.Content)
    .Where(HasBeginAndEnd)
    .Where(IsReplyMessage)
    .Select(ParseResponse);
    
