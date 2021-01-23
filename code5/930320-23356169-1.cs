    // in App.xaml.cs make a method and a listOfHandlers:
    private List<EventHandler<BackPressedEventArgs>> listOfHandlers = new List<EventHandler<BackPressedEventArgs>>();
    private void InvokingMethod(object sender, BackPressedEventArgs e)
    {
       for (int i = 0; i < listOfHandlers.Count; i++)
           listOfHandlers[i](sender, e);
    }
    public event EventHandler<BackPressedEventArgs> myBackKeyEvent
    {
       add { listOfHandlers.Add(value); }
       remove { listOfHandlers.Remove(value); }
    }
    // look that as it is a collection you can make a variety of things with it
    // for example provide a method that will put your new event on top of it
    // it will beinvoked as first
    public void AddToTop(EventHandler<BackPressedEventArgs> eventToAdd) { listOfHandlers.Insert(0, eventToAdd); }
    // in App constructor:
    HardwareButtons.BackPressed += InvokingMethod;
    // subscription:
    (App.Current as App).myBackKeyEvent += MyClosingPopupHandler;
    // or
    (App.Current as App).AddToTop(MyClosingPopupHandler); // it should be fired first
