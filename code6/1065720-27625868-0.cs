    private void OnMyEvent(int i, int j, bool prevent)
    {
        MyEventDelegate handler = MyEvent;
        MyEventArgs e = new MyEventArgs(i, j, prevent);
        if (handler != null)
        {
            handler(this, e);
        }
        if (e.Prevent)
        {
            return;
        }
 
        // Member of same class, and we already know Prevent is false,
        // so just need to pass i and j.
        DefaultBehaviourFunction(i, j);
    }
