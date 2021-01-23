    class ClosureClass1
    {
        public string message;
        public NewClass @this;
        public void AnonymousMethod1()
        {
            @this.txtMessage.Text = message;
        }
    }
    void UpdateMessage(NewClass this, string message)
    {
        ClosureClass1 closure = new ClosureClass1();
        closure.@this = this;
        closure.message = message;
        Action action = closure.AnonymousMethod1;
        Dispatcher.BeginInvoke(action);
    }
