    public void sendData(string eventCodes, IEnumerable<string> data = null)
    {
        string element;
        if (data != null)
            element = string.Join("\x01", new[] { eventCodes }.Concat(data));
        else
            element = eventCodes;
        push(element + "\x00");
    }
