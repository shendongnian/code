    /// <summary>Represents the method that can recieve a message.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="message">The message.</param>
    internal delegate void SendMessage(object sender, string message);
    /// <summary>Occurrs when the JoinServiceCallback method is invoked.</summary>
    public event SendMessage AfterJoinServiceCallback;
