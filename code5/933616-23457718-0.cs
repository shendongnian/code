    public Button(string Message, Action<object> func)
    {
        text = Message;
        doAction = func;
    }
    public void Clicked(object o)
    {
        doAction(o);
    }
