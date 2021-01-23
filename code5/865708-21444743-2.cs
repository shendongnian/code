    private void RunChat()
    {
        StreamReader reader = new StreamReader(client.GetStream());
        Delegate invoker = new Action<string>(AppendChatText);
        while (true)
            Invoke(invoker, reader.ReadLine());
    }
