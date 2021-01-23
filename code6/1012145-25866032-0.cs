    private string oldInput;
    
    ....
    
    void TimerTick(Object source, ElapsedEventArgs e)
    {
        if (oldInput != MyTextBox.Text) MyVoid(oldInput);
        oldInput = MyTextBox.Text;
    }
