    public void SetText(string text)
    {
        Action action = () => PageTitle.Text = text;
        Dispatcher.BeginInvoke(action);
    }
