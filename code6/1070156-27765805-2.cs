    public delegate void SetTextDelegate(TextBox tb, string text);
    public void SetText(TextBox tb, string text)
    {
         if (tb.InvokeRequired) 
         {
              tb.Invoke(new SetTextDelegate(SetText), tb, text);
              return;
         }
         tb.Text = text;
    }
