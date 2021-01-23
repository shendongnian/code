    public event TextCompositionEventHandler TextInputLinked = (sender, args) =>
    {
       MyTextBox textBox = (MyTextBox)sender;
       if (textBox.TextInputLinked != null)
       {
           foreach (var handler in textBox.TextInputLinked.GetInvocationList())
           {
              if (handler.Target != null) <-- Check to avoid Stack overflow exception
              {
                 handler.DynamicInvoke(sender, args);
              }
           }
       }
    };
    
    public MyTextBox()
    {
        this.AddHandler(TextBox.TextInputEvent, TextInputLinked, true);
    }
