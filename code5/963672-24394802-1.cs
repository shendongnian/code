    public event RoutedEventHandler MyEvent;
    private void button_Clicked(object sender, RoutedEventArgs e)
    {
        if (MyEvent != null)
            MyEvent(this, e);
    }
