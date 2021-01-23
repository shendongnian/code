    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
      try
      {
        this._value = Convert.ToDecimal(this.Text); // Assign private field instead of property, due to the next change.
      }
      catch { }
    }
    public decimal Value
    {
      get { return this._value; }
      set 
      { 
        this._value = value;
        this.Text = this._value.ToString("C"); // Set the text when Value is set.
      }
    }
