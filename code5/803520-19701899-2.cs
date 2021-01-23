    public void DisplayData(string msg)
    {
        _displayWindow.Dispatcher.Invoke(new Action(() => UpdateTextbox(msg)));
    }
    
    public void UpdateTextbox(string msg)
    {
        try
        {
            _displayWindow.Document.Blocks.Clear();
            _displayWindow.AppendText(msg);
            _displayWindow.ScrollToEnd();
        }
        catch (Exception ex)
        {
            //log ex
        }
    }
