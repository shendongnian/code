    public event EventHandler MyEvent;
    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (MyEvent != null)
        {
            MyEvent(this, EventArgs.Empty);
        }
    }
