    delegate void TextSetter(string text);
    internal void SetText(string text)
    {
      //call on main thread if necessary
      if (InvokeRequired)
      {
        this.Invoke((TextSetter)SetText, text);
        return;
      }
    
      //set the text on your label or whatever
      this.StatusLabel.Text = text;
    }
