    ActionBlock<string> _block;
    void MainLoop()
    {
      _block = new ActionBlock<string>(ProcessMessage);
      while (true)
      {
        var message = ReadFromExchange();
        _block.Post(message);
      }
    }
    void ProcessMessage(string message)
    {
      ...
    }
