    public void RaiseButton(char Tosend)
    {
        if (IsPressed != null)
        {
            IsPressed(this,txtbox.text);
        }
    }
