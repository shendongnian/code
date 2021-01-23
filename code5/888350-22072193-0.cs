    private async Task SaveAMessage(Messsage message)
    {
        var messages = new List<Message>();
        messages.Add(message);
        var envelope = new Envelope();
        envelope.messages = messages;
        await Task.WhenAll(_db.Save(envelope), Task.Delay(1000));
    }
