    private void RaisePropertyChanged(string propertyName)
    {
        //1: Test1 changes a property, and triggers this event.
        //   Because Test2 earlier subscribed to the event, PropertyChanged is not null here
        if (PropertyChanged != null)
        {
            //2: Test2 sneaks in from a different thread
            //   and *unsubscribes* from PropertyChanged, making it null again.
            //3: Test1 then gets a NullReferenceException here,
            //   because there's no local "handler" variable that kept the original delegate.
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
