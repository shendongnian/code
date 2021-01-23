    // A member method on the derived class of `System.Windows.Forms.Form` for the UI.
    public void MarshallDataToUI()
    {
        // Current thread: data queue consumer thread.
        // This call blocks if the data queue is empty.
        string text = TheDataQueue.Take();
        // Marshall the text to the UI thread.
        Invoke(new Action<string>(ReceiveText), text);
    }
    private void ReceiveText(string text)
    {
        // Display the text.
        textBoxDataFeed.Text = text;
        // Explicitly process all Windows messages currently in the message queue to force
        // immediate UI refresh.  We want the UI to display the very latest data, right?
        // Note that this can be relatively slow...
        Application.DoEvents();
    }
