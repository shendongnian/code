    public void Process<TMessageType>(T message) where TMessageType : IParent
    {
      ScreenRecorder.Start();
      message.Print();
    }
