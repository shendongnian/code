    public event EventHandler SomethingChanged;
    
    protected void OnSomethingChanged(EventArgs e)
    {
       if (SomethingChanged != null)
         SomethingChanged(this, e);
    }
    
    public string Class_Text
            {
                get { return Class; }
                set
                {
                    if (value != Class)
                    {
                        Class = value;
                        txtClass.Text = Class;
    
                        this.OnSomethingChanged(EventArgs.Empty);
                    }
                }
            }
