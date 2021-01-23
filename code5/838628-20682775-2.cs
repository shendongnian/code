    public void sendData(string eventCodes, IEnumerable<string> data = null)
    {
        if (data != null)
            push(string.Join("\x01", new[] { eventCodes }
                .Concat(data.Select(item => item.ToString()))) + "\x00");
        else
            push(eventCodes + "\x00");
    }
