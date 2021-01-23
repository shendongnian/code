    private void SetLabel1Text(string text)
    {
      if (InvokeRequired)
      {
        Invoke((Action<string>)SetLabel1Text, text);
        return;
      }
      label1.Text = text;
    }
