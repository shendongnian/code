    public string Text
    {
      get
      {
        return (string) this.GetValue(TextBox.TextProperty);
      }
      set
      {
        this.SetValue(TextBox.TextProperty, (object) value);
      }
    }
