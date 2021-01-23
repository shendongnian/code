    void UpdateMessage(NewClass this, string message)
    {
        Action action = () => this.txtMessage.Text = message;
        Dispatcher.BeginInvoke(action);
    }
